using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionScene : MonoBehaviour
{
    public GameObject[] dialogueScenes;
    public GameObject prompt;

    private int cooldownSeconds;
    private int sceneNum;

    public AudioSource end;

    void Start()
    {
        cooldownSeconds = 300; //given time to read the dialogue
        deactivateScenes();
        prompt.SetActive(false);
        ChangeScenes();
    }

    void Update()
    {
        if (cooldownSeconds > 0)
        {
            cooldownSeconds -= 1;
        }
        else
        {
            prompt.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene(sceneNum);
        }
    }

    public void deactivateScenes()
    {
        for (int i = 0; i < dialogueScenes.Length; i++)
        {
            dialogueScenes[i].SetActive(false);
        }
    }

    public void ChangeScenes()
    {
        
        switch (MainManager.Instance.currentSeason)
        {
            case "SPRING":
                deactivateScenes();
                dialogueScenes[0].SetActive(true);
                sceneNum = 1;
                break;
            case "SUMMER":
                deactivateScenes();
                dialogueScenes[1].SetActive(true);
                sceneNum = 2;
                break;
            case "AUTUMN":
                deactivateScenes();
                dialogueScenes[2].SetActive(true);
                sceneNum = 3;
                break;
            case "WINTER":
                deactivateScenes();
                dialogueScenes[3].SetActive(true);
                sceneNum = 4;
                break;
            case "END":
                end.Play();
                deactivateScenes();
                dialogueScenes[4].SetActive(true);
                sceneNum = 5;
                break;
        }

    }
}