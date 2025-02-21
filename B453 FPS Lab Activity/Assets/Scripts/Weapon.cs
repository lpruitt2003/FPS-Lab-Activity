using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // The location in space where the projectiles (or raycast) will be spawned.
    [SerializeField] protected Transform firePoint;

    // How much damage this weapon does.
    [SerializeField] protected float damage;

    // The range of this weapon.
    [SerializeField] protected float range;
    [SerializeField] protected float firerate;
    [SerializeField] protected int bulletCount;
    [SerializeField] protected int maxCapacity;
    [SerializeField] private PlayerController playerController;

    protected void Awake()
    {
        playerController = gameObject.Find("Player").GetComponent<PlayerController>();
        UIManager.Instance.UpdateAmmoUI(bulletCount, playerController.SpareRounds);
    }

    protected virtual void Shoot()
    {
        UiManager.Instance.UpdateAmmoUI(bulletCount, playerController.SpareRounds);
        if (bulletCount <= 0)
        {
            Reload();
        }
    }
    protected virtual void Reload()
    {
        StartCoroutine(ReloadCoroutine());
        // Code to reload the weapon.
    }

    protected IEnumerator ReloadCoroutine()
    {
        if (playerController.SpareRounds >= maxCapacity)
        {
            bykkeCount = maxCapacity;
            playerController.SpareRounds -= maxCapacity;
        }
        
        yield return new WaitForSeconds(1f);

        UImanager.Instance.UpdateAmmoUI(bulletCount, playerController.SpareRounds);
    }
}
