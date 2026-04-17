using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DayManager : MonoBehaviour, IInteractable 
{ //this will manage the days that the player has gone through
    public int daysGone;

    public string Season;
    public string[] Seasons;

    private ItemHolding heldItem;
    private SeasonManager seasonManager;

    public GameObject[] plantSpots;

    public TMP_Text dayCounterText;
    public TMP_Text seasonCounterText;
    public static event Action<int> OnDayPassed;

    private void Start()
    {
        daysGone = 1;
        string[] Seasons = {"SPRING", "SUMMER", "AUTUMN", "WINTER"};
        dayCounterText.text = "Day : " + daysGone.ToString();
        seasonCounterText.text = Season;

        seasonManager = GameObject.Find("Farmhouse").GetComponent<SeasonManager>();
    }

    private void Update()
    {
        heldItem = GameObject.Find("Canvas - HUD").GetComponent<ItemHolding>();
    }

    public void nextDay()
    {
        daysGone += 1;
        OnDayPassed?.Invoke(1);
        dayCounterText.text = "Day : " + daysGone.ToString();
    }

    public void changeSeason()
    {
        //changes the seasons
        Season = "SUMMER";
    }

    public void Interact()
    {
        try
        {
            if (heldItem.heldItem.isBouquet) //check if the held item is a bouquet
            {
                Debug.Log("Checking bouquet contents");
                bool match = seasonManager.CheckContents(heldItem.heldItem.bouquetContents, Season);

                if (match)
                {
                    Debug.Log("Changing Season!");
                    seasonManager.ChangeSeason(Season);
                }
                else
                {
                    Debug.Log("Skipping to the next day...");
                    nextDay();
                }
                
            }
            else
            {
                Debug.Log("Skipping to the next day...");
                nextDay();
            }
        }
        catch
        {
            Debug.Log("Not holding a bouquet, skipping to next day instead...");
            nextDay();
        }
        
        
    }

}