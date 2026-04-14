using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class SellingManager : MonoBehaviour
{
    [Header("Menu Objects")]
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    public GameObject Crosshair;
    public GameObject sellMenu;
    public GameObject buyMenu;
    private bool menuActivated;

    [Header("Inventory Data")]
    public SellSlot[] sellSlot;
    public ItemSO[] itemSOs;
    public TMP_Text moneyText;
    public TMP_Text itemDescriptionText;
    public TMP_Text itemNameText;

    private InventoryManager inventoryManager;


    void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        moneyText.text = "£" + inventoryManager.money.ToString();  
        sellMenu.SetActive(false);
    }

    void OnEnable()
    {
        InventoryManager.BouquetAvailable += AddBouquets;
        SellBuyButton.GoToBuyMenu += ChangeToBuy;
    }
    void OnDisable()
    {
        InventoryManager.BouquetAvailable -= AddBouquets;
        SellBuyButton.GoToBuyMenu -= ChangeToBuy;
    }

    public void AddBouquets(ItemSO bouquetItem)
    {
        //to be called when a bouquet item is added to the inventory
        Debug.Log("Copy that, we have a bouquet inbound");

        for (int i = 0; i < sellSlot.Length; i++)
        {
            if(sellSlot[i].isFull == false && sellSlot[i].itemName == bouquetItem.itemName || sellSlot[i].quantity == 0)
            {
                int leftOverItems = sellSlot[i].AddItem(bouquetItem, 1);
                if (leftOverItems > 0)
                {
                    leftOverItems = sellSlot[i].AddItem(bouquetItem, 1);
                    
                }
                return;
                
            }
        }
    }

    public void ChangeToBuy()
    {
        sellMenu.SetActive(false);
        buyMenu.SetActive(true);
    }
}