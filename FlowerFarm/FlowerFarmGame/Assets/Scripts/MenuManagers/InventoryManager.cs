using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class InventoryManager : MonoBehaviour
{
    [Header("Menu Objects")]
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    public GameObject Crosshair;
    public GameObject bouquetMenu;
    public GameObject shopMenu;
    private bool menuActivated;

    [Header("Inventory Data")]
    public ItemSlot[] itemSlot;
    public ItemSO[] itemSOs;
    public double money;
    public TMP_Text moneyText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemNameText;

    public static event Action<ItemSO> FlowerAvailable;
    public static event Action<ItemSO> BouquetAvailable;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InventoryMenu.SetActive(false);
        PlayerHUD.SetActive(true);
        Crosshair.SetActive(true);

        money = 100;
        moneyText.text = "£" + money.ToString();

        DeselectAllSlots();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuActivated)
        {   
            Debug.Log("Tab pressed");
            //when inventory closed, deactivate menu and reactivate HUD
            InventoryMenu.SetActive(false);
            bouquetMenu.SetActive(false);
            shopMenu.SetActive(false);


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
            PlayerHUD.SetActive(false);
            Crosshair.SetActive(false);
            bouquetMenu.SetActive(false);
            shopMenu.SetActive(false);

            menuActivated = true;

            //make the cursor visibile and allow player to move it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //pause the game
            Time.timeScale = 0;
        }
        moneyText.text = "£" + money.ToString(); //update the money to reflect its current value
    }

    public int AddItem(int quantity, ItemSO itemSO)
    {
        Debug.Log("itemName = " + itemSO.itemName + " | quantity = " + quantity + " | description: " + itemSO.itemDescription);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].isFull == false && itemSlot[i].itemName == itemSO.itemName || itemSlot[i].quantity == 0)
            {
                int leftOverItems = itemSlot[i].AddItem(quantity, itemSO);
                if (leftOverItems > 0)
                {
                    leftOverItems = itemSlot[i].AddItem(quantity, itemSO);
                    
                }
                if (itemSO.isFlower)
                {
                    Debug.Log("Hazel, we have flowers");
                    FlowerAvailable?.Invoke(itemSO);
                }
                if (itemSO.isBouquet)
                {
                    Debug.Log("Hazel, we have a bouquet!");
                    BouquetAvailable?.Invoke(itemSO);

                }
                return leftOverItems;
                
            }
        }
        return quantity;
    }

    public void RemoveItem(int quantity, ItemSO itemSO)
    {
        Debug.Log("Removing " + quantity + " of item " + itemSO.itemName);

        for (int i = 0; i < itemSlot.Length; i++)
        {
            if(itemSlot[i].itemName == itemSO.itemName && itemSlot[i].itemPrice == itemSO.sellPrice && itemSlot[i].quantity > 0)
            {
                itemSlot[i].quantity -= 1;
                if (itemSlot[i].quantity == 0)
                {
                    itemSlot[i].RemoveItem(itemSO, 0);
                    itemSlot[i].selectedShader.SetActive(false);
                    itemSlot[i].thisItemSelected = false;
                }
                else
                {
                    int leftover = itemSlot[i].quantity;
                    Debug.Log("There are " + leftover + " left");
                    itemSlot[i].RemoveItem(itemSO, leftover);
                }
            }
        }
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].selectedShader.SetActive(false);
            itemSlot[i].thisItemSelected = false;
        }
    }

    public void updateDescription(string newName, string newDesc)
    {
        itemDescriptionText.text = newDesc;
        itemNameText.text = newName;
    }
}
