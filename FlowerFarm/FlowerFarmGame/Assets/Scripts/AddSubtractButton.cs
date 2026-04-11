using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class AddSubtractButton : MonoBehaviour, IPointerClickHandler
{
    //detect if a click has occurred on either the add or subtract button
    public bool isAdd; //add button is true, subtract button is false
    public ItemSO flowerToChange;
    public int choiceNumber;

     public static event Action<ItemSO, int> AddFlowerToBouquet;
     public static event Action<ItemSO, int> TakeFlowerFromBouquet;

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (isAdd)
            {   
                Debug.Log("We're adding a " + flowerToChange.itemName);
                AddFlowerToBouquet?.Invoke(flowerToChange, choiceNumber);
            }
            else if (!isAdd)
            {
                Debug.Log("We're removing a " + flowerToChange.itemName);
                TakeFlowerFromBouquet?.Invoke(flowerToChange, choiceNumber);
            }
        }
    }
}