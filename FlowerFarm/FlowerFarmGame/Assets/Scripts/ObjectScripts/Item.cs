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
    public ItemSO itemSO; //the item SO used to make the flower
    [TextArea]
    [SerializeField]
    private string itemDescription;
    private InventoryManager inventoryManager;

    void Start()
    {   //get the inventory canvas and manager script
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
    }

    public void Interact() //uses the interactor interface
    {
        if (gameObject != null)
        {
            Debug.Log("A hit, a fine hit!");
            int leftOverItems = inventoryManager.AddItem(quantity, itemSO); 
            //calls inventory manager's AddItem function
            if (leftOverItems <= 0)
            {
                Destroy(gameObject); //then deletes the game object if there are none left
            }
            else
            {
                quantity = leftOverItems; //if there are items left (say, a bundle of flowers)
                                        //then the quantity of the item is decreased
            }
        }
    }
}
