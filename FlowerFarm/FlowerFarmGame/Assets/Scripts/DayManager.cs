using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class DayManager : MonoBehaviour, IInteractable 
{ //this will manage the days that the player has gone through
    public int daysGone;

    public string Season;

    public GameObject[] plantSpots;
    public static DayManager current;

    public event Action onDayPassed;

    private void Start()
    {
        daysGone = 0;
        Season = "Spring";
    }

    public void DayPasses()
    {
        if (onDayPassed != null)
        {
            onDayPassed();
        }
    }

    public void nextDay()
    {
        daysGone += 1;

    }

    public void changeSeason()
    {
        //changes the seasons
        Season = "Summer";
    }

    public void Interact()
    {
        Debug.Log("Skipping to the next day...");
        nextDay();
    }

}