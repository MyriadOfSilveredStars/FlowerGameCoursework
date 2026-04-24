using UnityEngine;

public class Patrol : MonoBehaviour
{
    public float speed; //how fast they can move
    public Transform[] moveSpots;
    private int randomSpot; //this will pick a random position
    private float waitTime;
    public float startWaitTime;

    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length); //find a starting spot
        waitTime = startWaitTime;
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if(waitTime <= 0) //is it time for the animal to move on
            {
                
                randomSpot = Random.Range(0, moveSpots.Length); //get a new spot
                waitTime = startWaitTime; //restart waiting timer
            }
            else
            {
                waitTime -= Time.deltaTime; //otherwise reduce timer
            }
        }
    }
}
