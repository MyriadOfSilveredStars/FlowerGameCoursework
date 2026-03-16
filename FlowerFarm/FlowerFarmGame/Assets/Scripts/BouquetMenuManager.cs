using UnityEngine;

public class BouquetMenuManager : MonoBehaviour
{
    public GameObject BouquetMenu;
    public GameObject MenuBanner;

    private bool menuActivated;

    void Start()
    {
        BouquetMenu.SetActive(false);
        MenuBanner.SetActive(false);
    }
}
