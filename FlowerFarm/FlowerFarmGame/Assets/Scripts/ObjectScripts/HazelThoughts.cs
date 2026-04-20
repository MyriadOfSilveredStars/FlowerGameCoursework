using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class HazelThoughts : MonoBehaviour
{
    public GameObject DialogueBox;
    public TMP_Text DialogueText;

    private int cooldownSeconds;
    private bool active;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DialogueBox.SetActive(false);
        active = false;
    }

    void Update()
    {
        if (active == true)
        {
            if (cooldownSeconds > 0)
            {
                cooldownSeconds -= 1;
            }
            else
            {
                active = false;
                DialogueBox.SetActive(false);
            }
        }
        
    }
    
    public void ActivateText()
    {
        DialogueBox.SetActive(true);
        cooldownSeconds = 100;
        active = true;

    }
    // there will be various small functions to change the dialogue text

    // SEASON STARTING DIALOGUE
    public void SpringStart()
    {
        DialogueText.text = "New year, new me. I've got a list for a special bouquet I should deliver to the house, when I have time";
        ActivateText();
    }

    public void SummerStart()
    {
        DialogueText.text = "Lovely and warm out! Let's see what's on the list for this season's bouquet...";
        ActivateText();
    }

    public void AutumnStart()
    {
        DialogueText.text = "Another summer fades... Time for another special request";
        ActivateText();
    }

    public void WinterStart()
    {
        DialogueText.text = "..........";
        ActivateText();
    }


    //PLANTING ERRORS DIALOGUE
    public void NotASeed()
    {
        DialogueText.text = "I can't plant these";
        ActivateText();
    }

    public void NotHoldingAnythingSeed()
    {
        DialogueText.text = "I'll need some seeds if I'm to plant anything";
        ActivateText();
    }

    //GENERIC WRONG DIALOGUE
    public void NothingHeld()
    {
        DialogueText.text = "I'll head to bed now...";
        ActivateText();
    }

    public void NotABouquet()
    {
        DialogueText.text = "I haven't got the bouquet ready yet... Perhaps tomorrow";
        ActivateText();
    }

    public void NotAMatch()
    {
        DialogueText.text = "These aren't the right flowers... I'll try again tomorrow";
        ActivateText();
    }


    //WINTER ONLY DIALOGUE
    public void WinterWrongSpot()
    {
        DialogueText.text = "This... Isn't where this needs to go...";
        ActivateText();
    }

    public void WinterWrongItem()
    {
        DialogueText.text = "This isn't what she needs...";
        ActivateText();
    }

    public void WinterWrongCombo()
    {
        DialogueText.text = "This isn't what she'd want...";
        ActivateText();
    }

    public void WinterEmptyHand()
    {
        DialogueText.text = "I can't give her nothing... She deserves more...";
        ActivateText();
    }
}
