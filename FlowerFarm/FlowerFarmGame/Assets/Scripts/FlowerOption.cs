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

    [Header("Data")]
    private int flowerPrice;
    private int numFlowers;
    private int numFlowersInBouquet;
    private string flowerNameText;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        flowerName.text = "TestFlower";
        numFlowersInBouquet = 0;
        flowerQuantity.text = numFlowersInBouquet.ToString();

    }

    public void PopulateChoices(ItemSO flower, int quantity)
    { //fill the choice with the available flowers
        flowerSO = flower;
        numFlowers = quantity;
        flowerNameText = flower.itemName;
        flowerName.text = flowerNameText + " (x" + numFlowers.ToString() + ")";

        //give the add and subtract buttons the flowers required
        subtractButton.GetComponent<AddSubtractButton>().flowerToChange = flower;
        plusButton.GetComponent<AddSubtractButton>().flowerToChange = flower;

    }

    //This increase and decreases the quantity of flowers still available
    public void IncreaseQuantity(int increase)
    {
        numFlowers += increase;
        flowerName.text = flowerNameText + " (x" + numFlowers.ToString() + ")";
    }
    public void DecreaseQuantity(int decrease)
    {
        numFlowers -= decrease;
        flowerName.text = flowerNameText + " (x" + numFlowers.ToString() + ")";
    }

    //This will increase and decrease the number of flowers already in the bouquet
    public void AddFlowersToBouquet()
    {
        if(numFlowers > 0)
        {
            DecreaseQuantity(1);
            numFlowersInBouquet += 1;
            flowerQuantity.text = numFlowersInBouquet.ToString();
        }
    }

    public void TakeFlowersFromBouquet()
    {
        if (numFlowersInBouquet > 0)
        {
            IncreaseQuantity(1);
            numFlowersInBouquet -= 1;
            flowerQuantity.text = numFlowersInBouquet.ToString();
        }
    }
}
