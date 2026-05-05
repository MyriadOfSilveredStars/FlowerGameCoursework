using UnityEngine;

public class MapController : MonoBehaviour
{
    public bool mapActive;
    public GameObject mapCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mapActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(mapActive == false)
        {
            mapCanvas.SetActive(false);
        }
        else if(mapActive == true)
        {
            mapCanvas.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.M) && mapActive)
        {
            mapActive = false;
        }
        else if(Input.GetKeyDown(KeyCode.M) && !mapActive)
        {
            mapActive = true;
        }
    }
}
