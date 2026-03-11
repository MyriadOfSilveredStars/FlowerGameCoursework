using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Item : MonoBehaviour, IInteractable 
{
    [SerializeField]
    private string itemName; //the name of the object

    [SerializeField]
    private int quantity; //the quantity given when picked up

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
        inventoryManager.AddItem(itemName, quantity);
    }
}
