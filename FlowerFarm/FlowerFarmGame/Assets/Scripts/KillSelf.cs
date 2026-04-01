using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class KillSelf : MonoBehaviour
{
    public int timeNeeded;

        private void OnEnable()
    {
        PlantingSpot.KYS += KillMyself;
    }

    private void Disable()
    {
        PlantingSpot.KYS -= KillMyself;
    }

    private void KillMyself(int growTime, int daysPlanted)
    {
        if (timeNeeded == daysPlanted)
        {
            Destroy(gameObject);
            timeNeeded = -1;
        }
    }
}