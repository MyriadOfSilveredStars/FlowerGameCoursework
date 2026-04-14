using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;


public class ShopManager : MonoBehaviour
{
    [SerializeField] private List<ShopItems> springItems;
    [SerializeField] private List<ShopItems> summerItems;
    [SerializeField] private List<ShopItems> autumnItems;
    [SerializeField] private List<ShopItems> winterItems;

    [SerializeField] private ShopSlot[] shopSlots;

    private InventoryManager inventoryManager;

    public TMP_Text moneyText;
    public TMP_Text dialogue;

    public GameObject buyMenu;
    public GameObject sellMenu;

    private bool menuActivated;

    private void Start()
    {
        inventoryManager = GameObject.Find("Canvas - Inventory").GetComponent<InventoryManager>();
        PopulateShopItems();
        moneyText.text = "£" + inventoryManager.money.ToString();
    }

    void OnEnable()
    {
        SellBuyButton.GoToSellMenu += ChangeMenu;
    }

    void OnDisable()
    {
        SellBuyButton.GoToSellMenu += ChangeMenu;
    }

    public void PopulateShopItems()
    {
        for (int i = 0; i < springItems.Count && i < shopSlots.Length; i++)
        {
            ShopItems shopItem = springItems[i];
            shopSlots[i].Initialize(shopItem.itemSO, shopItem.price);
            shopSlots[i].gameObject.SetActive(true);
        }

        for (int i = springItems.Count; i < shopSlots.Length; i++)
        {
            shopSlots[i].gameObject.SetActive(false);

        }
    }


    public void TryBuyItem (ItemSO itemSO, int price)
    {
        if(itemSO != null && inventoryManager.money >= price)
        {
            Debug.Log("Buying " + itemSO.itemName + " for £" + price.ToString());
            inventoryManager.money -= price;
            moneyText.text = "£" + inventoryManager.money.ToString();
            inventoryManager.AddItem(1, itemSO);
        }
        else
        {
            dialogue.text = "Ain't got the cash for that, pardner. How's about you grow summin and sell it first?";
            Debug.Log("Ain't got the cash for that, pardner. How's about you grow summin and sell it first?");
        }
    }

    private bool HasSpaceForItem(ItemSO itemSO)
    {
        foreach(var slot in inventoryManager.itemSlot)
        {
            if(slot.itemName == itemSO.itemName)
            {
                return true;
            }
            else if (slot.itemDescription == null)
            {
                return true;
            }
            
        }
        return false;
    }

    private void ChangeMenu()
    {
        sellMenu.SetActive(true);
        buyMenu.SetActive(false);
        menuActivated = false;
    }

}

[System.Serializable]
public class ShopItems
{
    public ItemSO itemSO;
    public int price;
}
