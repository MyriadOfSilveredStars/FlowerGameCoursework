using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

[CreateAssetMenu(fileName = "New Item")]
public class ItemSO : ScriptableObject
{
    [Header("Item Data")]
    public string itemName;
    [TextArea]
    public string itemDescription;
    public Sprite inventoryIcon;
    public GameObject prefab;

    public ItemSO flowerSO;

    [Header("Item Stats")]
    public int growTime;
    public int buyPrice;
    public double sellPrice;
    public bool isFlower;
    public bool isBouquet;
    public bool isSeed;

    //if bouquet, needs this:
    public List<ItemSO> bouquetContents;

    

}
