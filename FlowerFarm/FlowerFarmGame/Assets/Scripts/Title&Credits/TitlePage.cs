using UnityEngine;
using UnityEngine.SceneManagement;

public class TitlePage : MonoBehaviour
{

    void OnEnable()
    {
        TitleButtons.OnOptionChosen += ButtonPress;
    }

    void OnDisable()
    {
        TitleButtons.OnOptionChosen -= ButtonPress;
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
                Debug.Log("Looking at controls..."); //load the controls screen
                break;
            case "EXIT":
                Debug.Log("Closing game...");
                break;
        }
    }
}
