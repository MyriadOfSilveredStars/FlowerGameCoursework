using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SellSlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO sellableItem;
    public bool isFull;
    public int quantity;
    private InventoryManager inventoryManager;
    private SellingManager sellingManager;

    public double itemPrice;
    public string itemName;
    public Sprite itemSprite;
    public Image itemImage;
    public Sprite emptySprite;
    private int maxNumberOfItems;
    public TMP_Text quantityText;

    public GameObject selectedShader;
    public bool thisItemSelected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        sellingManager = GameObject.Find("Canvas - Selling").GetComponent<SellingManager>();
        this.maxNumberOfItems = 64;
    }

    public int AddItem(ItemSO addedItem, int quantity)
    {
        this.maxNumberOfItems = 64;
        //Check to see if the slot is already full
        if (isFull)
        {
            return quantity;
        }

        //update what is being held
        this.sellableItem = addedItem;

        //Update NAME
        this.itemName = addedItem.itemName;
        this.itemPrice = addedItem.sellPrice;

        //Update image
        this.itemSprite = addedItem.inventoryIcon;
        itemImage.sprite = addedItem.inventoryIcon;

        //Update quantity
        this.quantity += quantity;

        if (this.quantity >= this.maxNumberOfItems)
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

    public void RemoveItem(ItemSO itemSO, int quantity)
    {
        if (quantity == 0)
        {
            EmptySlot();
        }
        else
        {
            this.quantity -= quantity;
            //update quantity text
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {   
            Debug.Log("Selling the item");
            OnLeftClick(); //sell the item
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log("Inspecting the item");
            OnRightClick(); //get info about the item
        }
    }

    public void OnRightClick()
    {
        //the merchant will buy the item from the player
        Debug.Log("Quantity = " + this.quantity.ToString());
        if (this.quantity > 0)
        {
            inventoryManager.RemoveItem(1, sellableItem); //and from the main inventory
            sellingManager.RemoveBouquets(1, sellableItem); //remove from the shop
            
            inventoryManager.money += itemPrice;
        }
        
    }

    public void OnLeftClick()
    {
        //the merchant will comment on this item
        sellingManager.DeselectAllSlots();

        selectedShader.SetActive(true);
        thisItemSelected = true;
        if (this.quantity > 0)
        {
            sellingManager.merchantDialogue.text = "Ah, what a wonderful " + itemName + ". Lovely work as always, Hazel. I'll give you £"  + itemPrice + " for it.";
        }
        else
        {
            sellingManager.merchantDialogue.text = "Any bouquets for me? You know how much the townies love 'em!";
        }
        
    }

    public void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        //update what is being held
        this.sellableItem = null;
        
    }
}
