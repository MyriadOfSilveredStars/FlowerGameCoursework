using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class FlowerMerchant : MonoBehaviour, IInteractable 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject ShopMenu;
    public GameObject PlayerHUD;
    public GameObject Crosshair;
    public GameObject InteractCrosshair;
    
    private bool menuOpen;

    void Start()
    {
        ShopMenu.SetActive(false);
        menuOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && menuOpen)
        {
            Debug.Log("Well, be seein' ya!");
            ShopMenu.SetActive(false);
            PlayerHUD.SetActive(true);
            Crosshair.SetActive(true);

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            Time.timeScale = 1;

            menuOpen = false;
        }
    }

    public void Interact()
    {
        Debug.Log("Howdy. I'm your local flower merchant");

        ShopMenu.SetActive(true);
        PlayerHUD.SetActive(false);
        Crosshair.SetActive(false);
        InteractCrosshair.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;

        menuOpen = true;
        
    }
}
