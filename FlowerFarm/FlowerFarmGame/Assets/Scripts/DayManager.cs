using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;

public class DayManager : MonoBehaviour, IInteractable 
{ //this will manage the days that the player has gone through
    public int daysGone;

    public string Season;

    public GameObject[] plantSpots;

    public TMP_Text dayCounterText;
    public TMP_Text seasonCounterText;
    public static event Action<int> OnDayPassed;

    private void Start()
    {
        daysGone = 1;
        Season = "SPRING";
        dayCounterText.text = "Day : " + daysGone.ToString();
        seasonCounterText.text = Season;
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
        Season = "Summer";
    }

    public void Interact()
    {
        Debug.Log("Skipping to the next day...");
        nextDay();
    }

}