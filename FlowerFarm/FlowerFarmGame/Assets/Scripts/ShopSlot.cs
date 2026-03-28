using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class ShopSlot : MonoBehaviour, IPointerClickHandler
{
    public ItemSO itemSO;
    public TMP_Text itemNameText;
    public TMP_Text priceText;
    public Image itemImage;

    private ShopManager shopManager;

    private int price;

    private void Start()
    {
        shopManager = GameObject.Find("Canvas - Merchant").GetComponent<ShopManager>();
    }
    public void Initialize(ItemSO newItemSO, int price)
    {
        //fill the slot with the correct information
        itemSO =newItemSO;
        itemNameText.text = itemSO.itemName;
        this.price = price;
        priceText.text = price.ToString();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Alrighty partner!");
            shopManager.TryBuyItem(itemSO, price);
        }
    }
}
