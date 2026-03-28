using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    [Header("Item Data")]
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Sprite inventoryIcon;
    public string prefabName;

    [Header("Item Stats")]
    public int growTime;
    public int buyPrice;
    public int sellPrice;
    public bool isFlower;
    public bool isBouquet;
    public bool isSeed;

    

}
