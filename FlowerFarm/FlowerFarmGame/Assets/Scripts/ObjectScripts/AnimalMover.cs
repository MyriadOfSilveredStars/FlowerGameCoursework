using UnityEngine;
using UnityEngine.AI;

public class AnimalMover : MonoBehaviour
{
    [SerializeField] private string animalType; //can be horse, deer, or dog
    private string currentState;
    private Animator animator;

    public NavMeshAgent agent;
    [SerializeField] private LayerMask groundLayer, playerLayer;

    //for the random patrol
    Vector3 destinationPoint;
    bool walkpointSet; //does this specific creature have a destination or not
    [SerializeField] float range; //how far they can walk

    //for the less random patrol
    public Transform[] moveSpots;
    private int randomSpot; //this will pick a random position
    private float waitTime;
    public float startWaitTime;



    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Idling", true);
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("Grazing", false);

        currentState = "IDLE";

        agent = GetComponent<NavMeshAgent>();

        randomSpot = Random.Range(0, moveSpots.Length); //find a starting spot
        waitTime = startWaitTime;

    }

    void Update()
    {
        PatrolField();
    }

    public void PatrolField()
    {
        agent.SetDestination(moveSpots[randomSpot].position);
        animator.SetBool("Walking", true);
        animator.SetBool("Grazing", false);
        animator.SetBool("Idling", false);

        if(Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 1f)
        {
            if(waitTime <= 0) //is it time for the animal to move on
            {
                animator.SetBool("Walking", true);
                animator.SetBool("Grazing", false);
                animator.SetBool("Idling", false);
                randomSpot = Random.Range(0, moveSpots.Length); //get a new spot
                waitTime = startWaitTime; //restart waiting timer
            }
            else
            {
                waitTime -= Time.deltaTime; //otherwise reduce timer
                animator.SetBool("Grazing", true);
                animator.SetBool("Walking", false);
                animator.SetBool("Idling", false);
            }
        }
        
    }

    //boolean changing functions
    public void Idle()
    {
        animator.SetBool("Idling", true);

        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("Grazing", false);
    }

    public void Walk()
    {
        animator.SetBool("Walking", true);

        animator.SetBool("Idling", false);
        animator.SetBool("Running", false);
        animator.SetBool("Grazing", false);
    }

    public void Run()
    {
        animator.SetBool("Running", true);

        animator.SetBool("Idling", false);
        animator.SetBool("Walking", false);
        animator.SetBool("Grazing", false);
    }

    public void Graze()
    {
        animator.SetBool("Grazing", true);

        animator.SetBool("Idling", false);
        animator.SetBool("Running", false);
        animator.SetBool("Walking", false);
    }

}
