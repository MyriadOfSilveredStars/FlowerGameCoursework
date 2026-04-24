
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

    private DayManager dayManager;
    
    private bool menuOpen;

    public TMP_Text dialogue;

    [TextArea] public string[] dialogueOptionsSpring;
    [TextArea] public string[] dialogueOptionsSummer;
    [TextArea] public string[] dialogueOptionsAutumn;
    [TextArea] public string[] dialogueOptionsWinter;

    public string[] seasonDialogueOptions;
    [TextArea] public string[] noMoneyDialogue;

    private Animator animator;

    void Start()
    {
        ShopMenu.SetActive(false);
        menuOpen = false;
        
        dayManager = GameObject.Find("DaySkipper").GetComponent<DayManager>();

        switch (dayManager.Season)
        {
            case "SPRING":
                seasonDialogueOptions = dialogueOptionsSpring;
                break;
            
            case "SUMMER":
                seasonDialogueOptions = dialogueOptionsSummer;
                break;

            case "AUTUMN":
                seasonDialogueOptions = dialogueOptionsAutumn;
                break;

            case "WINTER":
                seasonDialogueOptions = dialogueOptionsWinter;
                break;
        }

        animator = GameObject.Find("Samiarose").GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && menuOpen)
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

    public void OnEnable()
    {
        Interactor.TalkingTime += changeAnimation;
    }

    public void Disable()
    {
        Interactor.TalkingTime -= changeAnimation;
    }

    public void changeAnimation(bool facing)
    {
        if (facing)
        {
            animator.SetBool("Talking", true);
            animator.SetBool("Idling", false);
        }

        if (facing == false)
        {
            animator.SetBool("Idling", true);
            animator.SetBool("Talking", false);
        }
    }

    public void Interact()
    {
        if (menuOpen == false)
        {
            Debug.Log("Howdy. I'm your local flower merchant");
            dialogue.text = seasonDialogueOptions[randomDialogue()];

            ShopMenu.SetActive(true);
            PlayerHUD.SetActive(false);
            Crosshair.SetActive(false);

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

            Time.timeScale = 0;

            menuOpen = true;
        }
        
        
    }

    private int randomDialogue()
    {
        int option = Random.Range(0, 6);
        return option;
    }
}
