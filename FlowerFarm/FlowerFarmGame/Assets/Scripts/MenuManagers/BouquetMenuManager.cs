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

    public TMP_Text bouquetPriceText;

    //Bouquet Data
    private List<ItemSO> BouquetSelection;
    private double bouquetPrice;
    [SerializeField]
    private Sprite bouquetIcon;
    private InventoryManager inventoryManager;

    void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();

        BouquetMenu.SetActive(false);
        NoFlowerMessage.SetActive(true);

        FlowerChoices = new ItemSO[4];
        quantities = new int[4] {0, 0, 0, 0};

        for (int i = 0; i < optionPanels.Length; i++)
        {
            optionPanels[i].SetActive(false);
        }
        BouquetSelection = new List<ItemSO>();
        bouquetPrice = 0;
    }

    // EVENT LISTENERS - Listening for various events here
    private void OnEnable()
    {
        InventoryManager.FlowerAvailable += RecieveFlowers;
        AddSubtractButton.AddFlowerToBouquet += AddToBouquet;
        AddSubtractButton.TakeFlowerFromBouquet += TakeFromBouquet;
        ConfirmBouquetButton.ConfirmBouquetSelection += CreateBouquet;
    }

    private void Disable()
    {
        InventoryManager.FlowerAvailable -= RecieveFlowers;
        AddSubtractButton.AddFlowerToBouquet -= AddToBouquet;
        AddSubtractButton.TakeFlowerFromBouquet -= TakeFromBouquet;
        ConfirmBouquetButton.ConfirmBouquetSelection -= CreateBouquet;
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
        try
        {
            NoFlowerMessage.SetActive(false);
        }
        catch
        {
            Debug.Log("I am honestly not sure why it's decided this doesn't exist");
        }
        
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

    public void CalculatePrice()
    {    
        bouquetPrice = 0;
        for (int i = 0; i < BouquetSelection.Count; i++)
        {
            bouquetPrice += BouquetSelection[i].sellPrice * 1.1;
        }
        bouquetPriceText.text = "Bouquet Worth : £ " + bouquetPrice.ToString();
    }

    public void AddToBouquet(ItemSO flowerToAdd, int choiceNumber)
    {
        bool canDo = flowerOption[choiceNumber].AddFlowersToBouquet(); //update this visually

        if (canDo) //check that flowers can be added to bouquet
        {
            Debug.Log("Adding " + flowerToAdd.itemName + " to this bouquet!");
            BouquetSelection.Add(flowerToAdd);
            quantities[choiceNumber] -= 1;

            CalculatePrice();
            inventoryManager.RemoveItem(1, flowerToAdd);
        }
        
    }

    public void TakeFromBouquet(ItemSO flowerToRemove, int choiceNumber)
    {
        bool canDo = flowerOption[choiceNumber].TakeFlowersFromBouquet();
        if (canDo) //check that flowers can be taken from bouquet
        {
            Debug.Log("Removing " + flowerToRemove.itemName + " from this bouquet!");
            BouquetSelection.Remove(flowerToRemove); //update this visually
            quantities[choiceNumber] += 1;

            CalculatePrice();
            inventoryManager.AddItem(1, flowerToRemove);
        }
        
    }

    public void CreateBouquet()
    {
        try
        {
            Debug.Log("Making dis bouquet");
            ItemSO finishedBouquet = ScriptableObject.CreateInstance<ItemSO>();

            finishedBouquet.itemName = CalculateName(BouquetSelection);
            finishedBouquet.itemDescription = CalculateDescription(BouquetSelection);
            finishedBouquet.sellPrice = bouquetPrice;
            finishedBouquet.isBouquet = true;
            finishedBouquet.inventoryIcon = bouquetIcon;

            finishedBouquet.bouquetContents = BouquetSelection;
            inventoryManager.AddItem(1, finishedBouquet);

            ResetMenu();
        }
        catch
        {
            Debug.Log("No items in bouquet...");
        }
        

    }

    public string CalculateName(List<ItemSO> bouquetContents)
    {
        return bouquetContents[0].itemName + " Bouquet";
    }

    public string CalculateDescription(List<ItemSO> bouquetContents)
    {
        return "A gorgeous bouquet, filled with " + bouquetContents[0].itemName;
    }

    public void ResetMenu()
    {
        //reset the bouquet menu so we can start again
        BouquetSelection = new List<ItemSO>();
        bouquetPrice = 0;

        for (int i = 0; i < 4; i++)
        {
            flowerOption[i].ResetMenu();
        }
    }
}
