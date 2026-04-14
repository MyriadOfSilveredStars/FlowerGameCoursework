using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SellSlot : MonoBehaviour
{
    public ItemSO sellableItem;
    public bool isFull;
    public int quantity;
    private InventoryManager inventoryManager;

    private double itemPrice;
    public string itemName;
    public Sprite itemSprite;
    public Image itemImage;
    private int maxNumberOfItems;
    public TMP_Text quantityText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        this.maxNumberOfItems = 64;
    }

    public int AddItem(ItemSO addedItem, int quantity)
    {
        //Check to see if the slot is already full
        if (isFull)
        {
            return quantity;
        }

        //update what is being held
        this.sellableItem = addedItem;

        //Update NAME
        this.itemName = addedItem.itemName;

        //Update image
        this.itemSprite = addedItem.inventoryIcon;
        itemImage.sprite = addedItem.inventoryIcon;

        //Update quantity
        this.quantity += quantity;
        if (this.quantity >= maxNumberOfItems)
        {
            quantityText.text = quantity.ToString();
            quantityText.enabled = true;
            isFull = true;
            //return the leftovers
            int extrasItems = this.quantity - maxNumberOfItems;
            this.quantity = maxNumberOfItems;

            return extrasItems;
        }
        //update quantity text
        quantityText.text = this.quantity.ToString();
        quantityText.enabled = true;

        return 0;
    }
}
