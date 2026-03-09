using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{

    public GameObject Inventory;
    public bool inventoryIsClosed;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        inventoryIsClosed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (inventoryIsClosed)
            {
                Inventory.SetActive(true);
                inventoryIsClosed = false;
            }
            else
            {
                Inventory.SetActive(false);
                inventoryIsClosed = true;
            }
        }
    }
}
