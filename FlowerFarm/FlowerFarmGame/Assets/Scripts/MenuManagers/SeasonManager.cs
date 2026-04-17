using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

using System.Linq;


public class SeasonManager : MonoBehaviour
{

    public string Season;

    //REQUESTED BOUQUETS

    private Dictionary<string, int> SpringContents = new Dictionary<string, int>();
    private Dictionary<string, int> SummerContents = new Dictionary<string, int>();
    private Dictionary<string, int> AutumnContents = new Dictionary<string, int>();
    private Dictionary<string, int> WinterContents = new Dictionary<string, int>();

    //PLAYER'S BOUQUET (to be changed each check)
    private Dictionary<string, int> PlayerContents = new Dictionary<string, int>();
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   //starting season
        Season = "Spring";

        //set up what the contents NEED to be int he dictionaries
        SpringContents.Add("Purple Hyacinths", 3);
        SpringContents.Add("Forget-Me-Nots", 5);
        SpringContents.Add("Bluebells", 2);
        SpringContents.Add("Daffodils", 3);

        //do the other seasons later they aren't important yet
    }

    public bool CheckContents(List<ItemSO> BouquetContents, string currentSeason)
    {
        //first, create a dictionary for the player's bouquet
        for (int i = 0; i < BouquetContents.Count; i++){
            //if the dictionary is empty (it will be at the start)
            if (PlayerContents == null)
            {
                PlayerContents.Add(BouquetContents[i].itemName, 1);
            }
            //checks if the key exists already
            else if (PlayerContents.ContainsKey(BouquetContents[i].itemName))
            {
                PlayerContents[BouquetContents[i].itemName] += 1;
            }
            //if there is no key but the dict is not empty, add a new key-value pair
            else
            {
                PlayerContents.Add(BouquetContents[i].itemName, 1);
            }
        }

        //now check if the dictionaries are actually the same.

        switch(currentSeason) 
        {
        case "SPRING":
            //check agains the spring bouquet contents
            bool springEqual = PlayerContents.Count == SpringContents.Count && !PlayerContents.Except(SpringContents).Any();
            return springEqual;
        case "SUMMER":
            bool summerEqual = PlayerContents.Count == SummerContents.Count && !PlayerContents.Except(SummerContents).Any();
            return summerEqual;
        case "AUTUMN":
            bool autumnEqual = PlayerContents.Count == AutumnContents.Count && !PlayerContents.Except(AutumnContents).Any();
            return autumnEqual;
        case "WINTER":
            bool winterEqual = PlayerContents.Count == WinterContents.Count && !PlayerContents.Except(WinterContents).Any();
            return winterEqual;
        default:
            Debug.Log("Incorrect Season. No Match");
            return false;
        }



    }
}
