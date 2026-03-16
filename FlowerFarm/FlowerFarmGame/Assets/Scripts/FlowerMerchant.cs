using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

public class FlowerMerchant : MonoBehaviour, IInteractable 
{

    public GameObject Crosshair;
    public GameObject InteractCrosshair;
    public GameObject PlayerHUD;

    public GameObject MerchantScreen;
    private bool shopActivated;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MerchantScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && shopActivated)
        {   
            Debug.Log("Closing up shop...");
            //when inventory closed, deactivate menu and reactivate HUD

            MerchantScreen.SetActive(false);
            PlayerHUD.SetActive(true);
            Crosshair.SetActive(true);

            shopActivated = false;

            //make the cursor invisible and lock it for play
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            //unpause the game
            Time.timeScale = 1;
        }
    }

    public void Interact()
    {
        if (!shopActivated)
        {
            Debug.Log("Howdy. I'm your local flower merchant");

            MerchantScreen.SetActive(true);
            PlayerHUD.SetActive(false);
            Crosshair.SetActive(false);
            InteractCrosshair.SetActive(false);

            //make the cursor visibile and allow player to move it
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            //pause the game
            Time.timeScale = 0;

            shopActivated = true;
        }
    }
}
