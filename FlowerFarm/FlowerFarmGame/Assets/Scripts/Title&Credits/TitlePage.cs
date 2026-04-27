using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePage : MonoBehaviour
{

    public GameObject TitleScreen;
    public GameObject ControlsScreen;

    public GameObject[] HighlightedButtons;
    public GameObject ControlsHighlightedScreen;

    void Start()
    {
        TitleScreen.SetActive(true);
        ControlsScreen.SetActive(false);

        for (int i = 0; i < HighlightedButtons.Length; i++)
        {
            HighlightedButtons[i].SetActive(false);
        }
        ControlsHighlightedScreen.SetActive(false);
    }

    void OnEnable()
    {
        TitleButtons.OnOptionChosen += ButtonPress;
        TitleButtons.OnOptionHovered += ButtonHover;
    }

    void OnDisable()
    {
        TitleButtons.OnOptionChosen -= ButtonPress;
        TitleButtons.OnOptionHovered -= ButtonHover;
    }

    public void ButtonHover(string buttonName, bool isHovered)
    {
        switch (buttonName)
        {
            case "BEGIN":
                if (isHovered)
                {
                    HighlightedButtons[0].SetActive(true);
                    TitleScreen.SetActive(false);
                }
                else
                {
                    HighlightedButtons[0].SetActive(false);
                    TitleScreen.SetActive(true);
                }
            break;
            case "CONTROL":
                if (isHovered)
                {
                    HighlightedButtons[1].SetActive(true);
                    TitleScreen.SetActive(false);
                }
                else
                {
                    HighlightedButtons[1].SetActive(false);
                    TitleScreen.SetActive(true);
                }
            break;
            case "EXIT":
                if (isHovered)
                {
                    HighlightedButtons[2].SetActive(true);
                    TitleScreen.SetActive(false);
                }
                else
                {
                    HighlightedButtons[2].SetActive(false);
                    TitleScreen.SetActive(true);
                }
            break;
            case "RETURN":
                if (isHovered)
                {
                    ControlsHighlightedScreen.SetActive(true);
                    ControlsScreen.SetActive(false);
                }
                else
                {
                    ControlsHighlightedScreen.SetActive(false);
                    ControlsScreen.SetActive(true);
                }
            break;
        }
    }

    public void ButtonPress(string ButtonName)
    {
        switch (ButtonName)
        {
            case "BEGIN":
                Debug.Log("Starting game...");
                SceneManager.LoadScene(6); //load the first dialogue of the game
                break;
            case "CONTROL":
                Debug.Log("Looking at controls...");
                TitleScreen.SetActive(false);
                ControlsScreen.SetActive(true); //load the controls screen
                HighlightedButtons[1].SetActive(false);
                break;
            case "EXIT":
                Debug.Log("Closing game...");
                break;
            case "RETURN":
                Debug.Log("Return to main menu");
                TitleScreen.SetActive(true);
                ControlsScreen.SetActive(false);
                ControlsHighlightedScreen.SetActive(false);
                break;
        }
    }
}
