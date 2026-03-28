using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable 
{
    [SerializeField]
    private string itemName; //the name of the object

    [SerializeField]
    private int quantity; //the quantity given when picked up

    [SerializeField]
    private Sprite sprite; //the image used in the inventory

    [SerializeField]
    private ItemSO itemSO; //the item SO used to make the flower

    [TextArea]
    [SerializeField]
    private string itemDescription;

    private InventoryManager inventoryManager;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
    }

    void Update()
    {

    }

    public void Interact()
    {
        Debug.Log("A hit, a fine hit!");

        int leftOverItems = inventoryManager.AddItem(itemName, quantity, sprite, itemDescription, itemSO);

        if (leftOverItems <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            quantity = leftOverItems;
        }
        
    }
}
