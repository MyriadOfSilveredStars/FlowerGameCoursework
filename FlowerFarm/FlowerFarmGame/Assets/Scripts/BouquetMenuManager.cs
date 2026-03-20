using UnityEngine;

public class BouquetMenuManager : MonoBehaviour
{
    public GameObject BouquetMenu;
    public GameObject MenuBanner;

    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    public GameObject InventoryBanner;
    public GameObject Crosshair;

    private bool menuActivated;

    void Start()
    {
        BouquetMenu.SetActive(false);
        MenuBanner.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && menuActivated)
        {   
            Debug.Log("Tab pressed");
            //when inventory closed, deactivate menu and reactivate HUD
            InventoryMenu.SetActive(false);
            InventoryBanner.SetActive(false);
            BouquetMenu.SetActive(false);
            MenuBanner.SetActive(false);


            PlayerHUD.SetActive(true);
            Crosshair.SetActive(true);

            menuActivated = false;

            //make the cursor invisible and lock it for play
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //unpause the game
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.B) && !menuActivated)
        {   
            //show inventory and hide the HUD
            InventoryMenu.SetActive(false);
            InventoryBanner.SetActive(false);

            BouquetMenu.SetActive(true);
            MenuBanner.SetActive(true);

            PlayerHUD.SetActive(false);
            Crosshair.SetActive(false);

            menuActivated = true;

            //make the cursor visibile and allow player to move it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //pause the game
            Time.timeScale = 0;
        }
    }
}
