using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemHolding : MonoBehaviour
{

    public Image itemSprite;

    public ItemSO heldItem;
      public Sprite emptySprite;
    
    public void HoldItem(ItemSO itemSO)
    {

        if(itemSO != null)
        {
            Debug.Log("you are holding " + itemSO.itemName);
            itemSprite.sprite = itemSO.inventoryIcon;

            this.heldItem = itemSO;

            heldItem.itemName = itemSO.itemName;
            heldItem.itemDescription = itemSO.itemDescription;
            heldItem.inventoryIcon = itemSO.inventoryIcon;
        }
    }

    public void StowItem()
    {
        this.heldItem = null;
        itemSprite.sprite = emptySprite;
    }


}