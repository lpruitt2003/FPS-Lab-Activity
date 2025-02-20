using UnityEngine;

public class UIManager : MonoBehaviour
{

    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI AmmoText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        ammoText = GameObject.Find("ammoText").GetComponent<TextMeshProUGUI>();
    }

    public void UpdateAmmoUI(int currentAmmo, int ammoCapacity)
    {
        ammoText.text = currentAmmo + "/" + ammoCapacity;
    }
}
