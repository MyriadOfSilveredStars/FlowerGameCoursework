using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public StatToChange statToChange = new StatToChange();
    public int amountToChangeStat;

    public void BuySeeds()
    {
        return;
    }
    public void SellItem()
    {
        return;
    }

    public void Grow()
    {
        return;
    }





    public enum StatToChange
    {
        none,
        price, //how much it costs to buy the seeds
        sellprice, //how much it sells for
        growtime //tracks how long the flower will take to grow in days
    };
}
