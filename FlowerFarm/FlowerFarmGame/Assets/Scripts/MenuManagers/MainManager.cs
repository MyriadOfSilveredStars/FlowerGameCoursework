//This controls the money and the seasons throughout the game using Data Persistence

using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;
    public double playerMoney;
    public string currentSeason;
    //these variables carry across game scenes to ensure that data is not lost

    private void Awake()
    { 
        //ensures that only one instance of this main manager can exist
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}