using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    public GameObject InventoryBanner;
    public GameObject Crosshair;

    public GameObject bouquetMenu;
    public GameObject bouquetOptions;

    private bool menuActivated;

    public ItemSlot[] itemSlot;

    public ItemSO[] itemSOs;

    public int money;
    public TMP_Text moneyText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryMenu.SetActive(false);
        InventoryBanner.SetActive(false);
        PlayerHUD.SetActive(true);
        Crosshair.SetActive(true);

        money = 100;
        moneyText.text = "£" + money.ToString();
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
            bouquetMenu.SetActive(false);
            bouquetOptions.SetActive(false);


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
            bouquetMenu.SetActive(false);
            bouquetOptions.SetActive(false);

            menuActivated = true;

            //make the cursor visibile and allow player to move it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //pause the game
            Time.timeScale = 0;
        }
        moneyText.text = "£" + money.ToString(); //update the money to reflect its current value
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription, ItemSO itemSO)
    {
        Debug.Log("itemName = " + itemName + " | quantity = " + quantity + " | description: " + itemDescription);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false && itemSlot[i].itemName == itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(itemName, quantity, itemSprite, itemDescription, itemSO);
                if (leftOverItems > 0)
                {
                    leftOverItems = AddItem(itemName, leftOverItems, itemSprite, itemDescription, itemSO);
                }
                return leftOverItems;
            }
        }
        return quantity;
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }
}
