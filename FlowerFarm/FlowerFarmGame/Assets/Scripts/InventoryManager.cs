using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    public GameObject InventoryBanner;
    public GameObject Crosshair;
    private bool menuActivated;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryMenu.SetActive(false);
        InventoryBanner.SetActive(false);
        PlayerHUD.SetActive(true);
        Crosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuActivated)
        {   
            Debug.Log("Tab pressed");
            //when inventory closed, deactivate menu and reactivate HUD
            InventoryMenu.SetActive(false);
            InventoryBanner.SetActive(false);
            PlayerHUD.SetActive(true);
            Crosshair.SetActive(true);

            menuActivated = false;

            //make the cursor invisible and lock it for play
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //unpause the game
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && !menuActivated)
        {   
            //show inventory and hide the HUD
            InventoryMenu.SetActive(true);
            InventoryBanner.SetActive(true);
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

    public void AddItem(string itemName, int quantity)
    {
        Debug.Log("itemName = " + itemName + "quantity = " + quantity);
    }
}
