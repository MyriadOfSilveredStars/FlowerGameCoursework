using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class PlantingSpot : MonoBehaviour, IInteractable 
{
    private bool hasPlant;
    public int daysPlanted;
    private bool canBeGathered;
    private Vector3 spotCoords;
    public GameObject sprout;

    private DayManager dayManager;

    private ItemHolding heldItem;

    private InventoryManager inventoryManager;


    private void Start(){ //when the game starts, all spots are empty
    
        hasPlant = false;
        daysPlanted = 0;
        canBeGathered = false;
        heldItem = null;

        spotCoords = this.transform.position;

        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        dayManager = GameObject.Find("DaySkipper").GetComponent<DayManager>();

    }

    private void Update()
    {
        heldItem = GameObject.Find("Canvas - HUD").GetComponent<ItemHolding>();

    }

    private void OnDayPassing()
    {
        Debug.Log("Adding a day to this plant spot");
        this.daysPlanted += 1;
    }

    public void plantSeed()
    {
        try
        {
            if (!hasPlant) //if there isn't already a plant here, plant one
            {
                if(heldItem != null && heldItem.heldItem.isSeed)
                {
                    hasPlant = true;
                    Debug.Log("You've planted " + heldItem.heldItem.itemName + "!");
                    
                    this.sprout = Instantiate(heldItem.heldItem.prefab, this.spotCoords + new Vector3(0, 0.1f, 0), Quaternion.identity);

                    daysPlanted = 0;
                    inventoryManager.RemoveItem(1, heldItem.heldItem);
                }
                else if (!heldItem.heldItem.isSeed)
                {
                    Debug.Log("You can't plant that, it's not a seed!");
                }
                
            }
        }
        catch
        {
            Debug.Log("You aren't holding anything to plant!");
        }
        
    }

    public void spawnFlowerSprout()
    {
        //this will spawn a little sprout prefab on the plant spot
    }

    public void harvestFlower()
    {
        if (canBeGathered)
        {
            canBeGathered = false;
            hasPlant = false;
            daysPlanted = 0;
        }
    }

    public void Interact()
    {
        Debug.Log("Planting!");
        plantSeed();
        
    }
}