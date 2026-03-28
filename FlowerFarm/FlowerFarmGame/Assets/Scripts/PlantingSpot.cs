using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlantingSpot : MonoBehaviour, IInteractable 
{
    private bool hasPlant;
    private int daysPlanted;
    private bool canBeGathered;

    private ItemHolding heldItem;

    private void Start(){ //when the game starts, all spots are empty
        hasPlant = false;
        daysPlanted = 0;
        canBeGathered = false;
        heldItem = null;

    }

    private void Update()
    {
        heldItem = GameObject.Find("Canvas - HUD").GetComponent<ItemHolding>();
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
                    Debug.Log("You've planted a " + heldItem.heldItem.itemName + "!");
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