using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //ITEM DATA
    public string itemName;
    public int quantity;
    public Sprite itemSprite;
    public bool isFull;
    public string itemDescription;

    public ItemSO itemSO;

    //ITEM SLOT
    [Header("ITEM SLOT")]
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;  

    public Sprite emptySprite;

    [Header("ITEM DESCRIPTION")]
    //ITEM DESCRIPTION SLOT

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;
    private ItemHolding holdItem;

    [SerializeField]
    private int maxNumberOfItems;

    private void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        holdItem = GameObject.Find("Canvas - HUD").GetComponent<ItemHolding>();
    }

    public int AddItem(int quantity, ItemSO itemSO)
    {
        //Check to see if the slot is already full
        if (isFull)
        {
            return quantity;
        }

        //update what is being held
        this.itemSO = itemSO;

        //Update NAME
        this.itemName = itemSO.itemName;

        //Update image
        this.itemSprite = itemSO.inventoryIcon;
        itemImage.sprite = itemSO.inventoryIcon;

        //Update description
        this.itemDescription = itemSO.itemDescription;

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

    public void RemoveItem(ItemSO itemSO, int quantity)
    {
        if (quantity == 0)
        {
            EmptySlot();
        }
        else
        {
            this.quantity = quantity;
            //update quantity text
            quantityText.text = this.quantity.ToString();
            quantityText.enabled = true;
        }
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClick();
        }
        if(eventData.button == PointerEventData.InputButton.Right)
        {
            OnRightClick();
        }
    }

    public void EmptySlot()
    {
        quantityText.enabled = false;
        itemImage.sprite = emptySprite;

        //update what is being held
        this.itemSO = null;

        holdItem.StowItem();
    }

    public void OnLeftClick()
    {
        Debug.Log("Clicked on slot!");
        inventoryManager.DeselectAllSlots();

        
        selectedShader.SetActive(true);
        thisItemSelected = true;

        try
        {
            inventoryManager.updateDescription(itemSO.itemName, itemSO.itemDescription);
            holdItem.HoldItem(itemSO);
        }
        catch
        {
            inventoryManager.DeselectAllSlots();
        }
        
        
        
    }

    public void OnRightClick()
    {
        holdItem.StowItem();
        return;
    }
}
