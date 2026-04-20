using UnityEngine;

public class GraveScript : MonoBehaviour, IInteractable 
{

    private ItemHolding heldItem;
    private SeasonManager seasonManager;
    private HazelThoughts hazelThoughts;


    void Start()
    {
        seasonManager = GameObject.Find("Farmhouse").GetComponent<SeasonManager>();
        hazelThoughts = GameObject.Find("Canvas - HazelThoughts").GetComponent<HazelThoughts>();
    }

    // Update is called once per frame
    void Update()
    {
        heldItem = GameObject.Find("Canvas - HUD").GetComponent<ItemHolding>();
    }

    public void Interact()
    {
        try
        {
            if (heldItem.heldItem.isBouquet) //check if the held item is a bouquet
            {
                Debug.Log("Checking bouquet contents");
                bool match = seasonManager.CheckContents(heldItem.heldItem.bouquetContents, "WINTER");
                Debug.Log("Match : " + match.ToString());

                if (match) //for all seasons save winter, use the farmhouse
                {
                    Debug.Log("Changing Season!");
                    seasonManager.EndGame();
                }
                else
                {
                    Debug.Log("That's not what she'd want...");
                    hazelThoughts.WinterWrongCombo();
                }
                
            }
            else
            {
                hazelThoughts.WinterWrongItem();
                Debug.Log("Not a bouquet...");
            }
        }
        catch
        {   
            hazelThoughts.WinterEmptyHand();
            Debug.Log("Not holding a bouquet...");
        }
    }
}
