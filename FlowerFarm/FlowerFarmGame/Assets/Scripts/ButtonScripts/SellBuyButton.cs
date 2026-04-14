using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class SellBuyButton : MonoBehaviour, IPointerClickHandler
{
    //detect if a click has occurred on either the add or subtract button
    public bool isBuy; //add button is true, subtract button is false

     public static event Action GoToBuyMenu;
     public static event Action GoToSellMenu;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (isBuy)
            {   
                Debug.Log("Going to the buying menu");
                GoToBuyMenu?.Invoke();
            }
            else if (!isBuy)
            {
                Debug.Log("Going to the selling menu");
                GoToSellMenu?.Invoke();
            }
        }
    }
}