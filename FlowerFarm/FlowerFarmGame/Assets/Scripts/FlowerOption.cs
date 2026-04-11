using UnityEngine;
using TMPro;

public class FlowerOption : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject plusButton;
    public GameObject subtractButton;

    [Header("Option Text")]
    public TMP_Text flowerName;
    public TMP_Text flowerQuantity;

    [Header("Item SO")]
    public ItemSO flowerSO;
    private ItemSO bouquetSO;

    [Header("Data")]
    private int flowerPrice;
    private int numFlowers;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flowerName.text = "TestFlower";
        flowerQuantity.text = "0";

    }

    public void PopulateChoices(ItemSO flower, int quantity)
    { //fill the choice with the available flowers
        flowerSO = flower;
        flowerName.text = flower.itemName;
        numFlowers = quantity;
        flowerQuantity.text = numFlowers.ToString();
    }

    public void IncreaseQuantity(int increase)
    {
        numFlowers += increase;
        flowerQuantity.text = numFlowers.ToString();
    }

    public void DecreaseQuantity(int decrease)
    {
        numFlowers -= decrease;
        flowerQuantity.text = numFlowers.ToString();
    }
}
