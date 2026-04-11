using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;


public class BouquetMenuManager : MonoBehaviour
{
    [Header("Menu Objects")]
    public GameObject BouquetMenu;
    public GameObject InventoryMenu;
    public GameObject PlayerHUD;
    public GameObject Crosshair;
    private bool menuActivated;

    [Header("Menu Data")]
    private ItemSO[] FlowerChoices;
    private int[] quantities;
    public GameObject NoFlowerMessage;

    public FlowerOption[] flowerOption;
    public GameObject[] optionPanels;

    void Start()
    {
        BouquetMenu.SetActive(false);
        NoFlowerMessage.SetActive(true);

        FlowerChoices = new ItemSO[4];
        quantities = new int[4] {0, 0, 0, 0};

        for (int i = 0; i < optionPanels.Length; i++)
        {
            optionPanels[i].SetActive(false);
        }

    }

    private void OnEnable()
    {
        InventoryManager.FlowerAvailable += RecieveFlowers;
    }

    private void Disable()
    {
        InventoryManager.FlowerAvailable -= RecieveFlowers;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.B) && menuActivated)
        {   
            Debug.Log("B Pressed");
            //when inventory closed, deactivate menu and reactivate HUD
            InventoryMenu.SetActive(false);
            BouquetMenu.SetActive(false);


            PlayerHUD.SetActive(true);
            Crosshair.SetActive(true);

            menuActivated = false;

            //make the cursor invisible and lock it for play
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //unpause the game
            Time.timeScale = 1;
        }
        else if (Input.GetKeyDown(KeyCode.B) && !menuActivated)
        {   
            //show inventory and hide the HUD
            InventoryMenu.SetActive(false);

            BouquetMenu.SetActive(true);

            PlayerHUD.SetActive(false);
            Crosshair.SetActive(false);

            menuActivated = true;

            //make the cursor visibile and allow player to move it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //pause the game
            Time.timeScale = 0;
        }
    }

    public void RecieveFlowers(ItemSO flower)
    {
        NoFlowerMessage.SetActive(false);
        Debug.Log("Copy Housten, we have flowers. Some " + flower.itemName + " to be exact");

        for (int i = 0; i < FlowerChoices.Length; i++)
        {
            if (FlowerChoices[i] != null && FlowerChoices[i].itemName == flower.itemName)
            {
                quantities[i] += 1;
                flowerOption[i].IncreaseQuantity(1);
                return;
            }
            else if(FlowerChoices[i] == null)
            {
                FlowerChoices[i] = flower; //keeps track of the flower SOs
                flowerOption[i].PopulateChoices(flower, 1); //updates the item slot code
                quantities[i] += 1; //keeps track of the internal quantity
                optionPanels[i].SetActive(true); //the visible item slot
                return;
            }
        }

    }

    public void UseFlowers()
    {
        
    }
}
