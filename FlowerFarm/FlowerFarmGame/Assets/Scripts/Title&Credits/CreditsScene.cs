using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScene : MonoBehaviour
{
    public GameObject[] allScreens;

    private int cooldownSeconds;
    private int screenNum;

    void Start()
    {

        allScreens[0].SetActive(true);
        allScreens[1].SetActive(false);
        allScreens[2].SetActive(false);

        cooldownSeconds = 220;
        screenNum = 0;

    }

    void Update()
    {
        try
        { //run through the credits, there's only three pages
            if (cooldownSeconds > 0)
            {
                cooldownSeconds -= 1;
            }
            else
            {
                allScreens[screenNum].SetActive(false);
                screenNum += 1;

                allScreens[screenNum].SetActive(true);

                cooldownSeconds = 220;
            }
        }
        catch
        {
            Application.Quit(); //once we've seen all the credits, quit the game
        }
    }


}