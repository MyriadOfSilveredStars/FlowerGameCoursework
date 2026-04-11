using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ConfirmBouquetButton : MonoBehaviour, IPointerClickHandler
{
    //detects if a click has occurred on the confirm button

     public static event Action ConfirmBouquetSelection;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Confirming flower choices for this bouquet, what a lovely selction!");
            ConfirmBouquetSelection?.Invoke();
        }
    }
}