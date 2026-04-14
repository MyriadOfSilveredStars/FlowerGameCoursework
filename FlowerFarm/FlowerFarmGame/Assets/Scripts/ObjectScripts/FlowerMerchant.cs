
using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using TMPro;

public class FlowerMerchant : MonoBehaviour, IInteractable 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject ShopMenu;
    public GameObject SellMenu;
    public GameObject PlayerHUD;
    public GameObject Crosshair;
    
    private bool menuOpen;

    public TMP_Text dialogue;

    [TextArea] public string[] dialogueOptionsSpring;
    [TextArea] public string[] dialogueOptionsSummer;
    [TextArea] public string[] dialogueOptionsAutumn;
    [TextArea] public string[] dialogueOptionsWinter;
    [TextArea] public string[] noMoneyDialogue;

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
            SellMenu.SetActive(false);
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

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        Time.timeScale = 0;

        menuOpen = true;
        dialogue.text = dialogueOptionsSpring[randomDialogue()];
        
    }

    private int randomDialogue()
    {
        int option = Random.Range(0, 6);
        return option;
    }
}
