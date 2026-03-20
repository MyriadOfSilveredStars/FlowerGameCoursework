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

    //ITEM SLOT
    [SerializeField]
    private TMP_Text quantityText;

    [SerializeField]
    private Image itemImage;  

    //ITEM DESCRIPTION SLOT
    public TMP_Text ItemDescriptionNameText;
    public TMP_Text ItemDescriptionText;

    public GameObject selectedShader;
    public bool thisItemSelected;
    private InventoryManager inventoryManager;

    [SerializeField]
    private int maxNumberOfItems;

    private void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
    }

    public int AddItem(string itemName, int quantity, Sprite itemSprite, string itemDescription)
    {
        //Check to see if the slot is already full
        if (isFull)
        {
            return quantity;
        }

        //Update NAME
        this.itemName = itemName;

        //Update image
        this.itemSprite = itemSprite;
        itemImage.sprite = itemSprite;

        //Update description
        this.itemDescription = itemDescription;

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

    public void OnLeftClick()
    {
        inventoryManager.DeselectAllSlots();
        selectedShader.SetActive(true);
        thisItemSelected = true;

        ItemDescriptionNameText.text = itemName;
        ItemDescriptionText.text = itemDescription;
    }

    public void OnRightClick()
    {
        return;
    }
}
