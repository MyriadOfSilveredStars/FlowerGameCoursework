using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MenuChanger : MonoBehaviour, IPointerClickHandler
{
    public GameObject inventoryMenu;
    public GameObject inventoryOptions;
    public GameObject bouquetMenu;
    public GameObject bouquetOptions;

    private bool menuSelected; //if false, it's the inventory, if true it's the bouquet menu

    public void Start()
    {
        menuSelected = false;
    }
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            if (menuSelected == false)
            {
                inventoryMenu.SetActive(false);
                inventoryOptions.SetActive(false);
                bouquetMenu.SetActive(true);
                bouquetOptions.SetActive(true);

                menuSelected = true;
            }
            else if(menuSelected == true)
            {
                inventoryMenu.SetActive(true);
                inventoryOptions.SetActive(true);
                bouquetMenu.SetActive(false);
                bouquetOptions.SetActive(false);

                menuSelected = false;
            }
        }
    }
}
