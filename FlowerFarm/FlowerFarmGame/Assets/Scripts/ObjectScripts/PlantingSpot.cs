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
    public GameObject sproutPrefab;
    private ItemHolding heldItem;
    private ItemSO itemPlanted;

    private InventoryManager inventoryManager;
    private HazelThoughts hazelThoughts;

    public static event Action<int, int> KYS;


    private void Start(){ //when the game starts, all spots are empty
    
        hasPlant = false;
        daysPlanted = 0;
        canBeGathered = false;
        heldItem = null;

        spotCoords = this.transform.position;

        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        hazelThoughts = GameObject.Find("Canvas - HazelThoughts").GetComponent<HazelThoughts>();

    }

    private void Update()
    {
        heldItem = GameObject.Find("Canvas - HUD").GetComponent<ItemHolding>();

    }

    private void OnEnable()
    {
        DayManager.OnDayPassed += IncreaseDays;
    }

    private void Disable()
    {
        DayManager.OnDayPassed -= IncreaseDays;
    }

    private void IncreaseDays(int numDays)
    {
        if (hasPlant)
        {
            this.daysPlanted += numDays;    
            maturePlant();
        }
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
                    itemPlanted = heldItem.heldItem;

                    GameObject spotSprout = Instantiate(sproutPrefab, this.spotCoords + new Vector3(0, 0.01f, 0), Quaternion.identity);
                    spotSprout.GetComponent<KillSelf>().timeNeeded = itemPlanted.growTime;

                    daysPlanted = 0;
                    inventoryManager.RemoveItem(1, heldItem.heldItem);

                    //make the white spot go away while the plant grows
                    this.transform.position += new Vector3(0, -1f, 0);

                }
                else if (!heldItem.heldItem.isSeed)
                {
                    hazelThoughts.NotASeed();
                    Debug.Log("You can't plant that, it's not a seed!");
                }
                
            }
        }
        catch
        {   
            hazelThoughts.NotHoldingAnythingSeed();
            Debug.Log("You aren't holding anything to plant!");
        }
        
    }

    public void maturePlant()
    {
        if (hasPlant)
        {
            if (daysPlanted == itemPlanted.growTime)
            {
                KYS?.Invoke(itemPlanted.growTime, daysPlanted); //destroy the sprout
                GameObject flower = Instantiate(itemPlanted.prefab, this.spotCoords + new Vector3(0, 0.01f, 0), Quaternion.identity);
                flower.GetComponent<Item>().itemSO = itemPlanted.flowerSO;

                //make the white spot come back when the flower is ready to be gathered
                this.transform.position += new Vector3(0, 1, 0);
                //reset the spot's data
                hasPlant = false;
                daysPlanted = 0;
                canBeGathered = false;
                heldItem = null;
            }
        }
    }

    public void Interact()
    {
        plantSeed();   
    }
}