using UnityEngine;
using UnityEngine.AI;

public class AnimalMover : MonoBehaviour
{
    [SerializeField] private string animalType; //can be horse, deer, or dog
    private string currentState;
    private Animator animator;

    private bool isFollow; //for the dog only, to check if it's following or not

    public NavMeshAgent agent;
    [SerializeField] private LayerMask groundLayer, playerLayer;
    [SerializeField] private GameObject player;
    private float runDistance = 10.0f; //range where deer will start running
    private float heelDistance = 3.0f; //range at which playmobil will heel, rather than follow
    private float catchUpDistance = 6.0f; //rnage at which the dog needs to start running

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

    public void OnEnable()
    {
        DogPetter.DogPetted += MakeFollow;
    }

    public void OnDisable()
    {
        DogPetter.DogPetted -= MakeFollow;
    }

    void Update()
    {
        switch (animalType)
        {
            case "HORSE":
                PatrolField();
                break;
            case "STAG":
                //logic to check if player is nearby
                float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);
                if (distanceFromPlayer <= runDistance) //run from player if too close
                {
                    animator.SetBool("Running", true);
                    animator.SetBool("Walking", false);
                    animator.SetBool("Idling", false);
                    RunAway();
                }
                else
                {
                    animator.SetBool("Running", false);
                    animator.SetBool("Walking", true);
                    PatrolField();
                }
                break;

            case "DOG":
                if (!isFollow) //the dog will wander around
                {
                    animator.SetBool("Walking", true);
                    PatrolField();
                }
                else //unless instructed to follow the player
                {
                    animator.SetBool("Walking", true);
                    FollowPlayer();
                }
                break;
        }
        
    }

    public void RunAway()
    {
        //change animation to running
        animator.SetBool("Running", true);
        animator.SetBool("Walking", false);
        animator.SetBool("Idling", false);

        agent.speed = 8f; //running should be faster

        Vector3 dirToPlayer = transform.position - player.transform.position; //locate the player's direction
        Vector3 newPos = transform.position + dirToPlayer; //move away from that direction
        agent.SetDestination(newPos); //move the agent
    }

    public void MakeFollow(bool following)
    {
        if (following == true)
        {
            isFollow = true;
        }
        else if (following == false)
        {
            isFollow = false;
        }
    }

    public void FollowPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceFromPlayer <= heelDistance)
        {
            animator.SetBool("Idling", true);
            animator.SetBool("Walking", false);
            animator.SetBool("Running", false);
        }
        else if(distanceFromPlayer >= catchUpDistance)
        {
            animator.SetBool("Idling", false);
            animator.SetBool("Walking", false);
            animator.SetBool("Running", true);
            agent.speed = 6f;
            Vector3 dirToPlayer = transform.position - player.transform.position; //locate the player's direction
            Vector3 newPos = transform.position - dirToPlayer; //move towards that direction
            agent.SetDestination(newPos); //move the agent
        }
        else //stops dog from pushing you around
        {
            animator.SetBool("Idling", false);
            animator.SetBool("Walking", true);
            animator.SetBool("Running", false);
            agent.speed = 3f;
            Vector3 dirToPlayer = transform.position - player.transform.position; //locate the player's direction
            Vector3 newPos = transform.position - dirToPlayer; //move towards that direction
            agent.SetDestination(newPos); //move the agent
        }

        
    }

    public void PatrolField()
    {
        agent.speed = 1.2f;
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
                animator.SetBool("Idling", true);
                if (animalType == "STAG")
                {
                    animator.SetBool("Idling", true);
                    animator.SetBool("Grazing", false);
                }
                else if(animalType == "HORSE")
                {
                    animator.SetBool("Grazing", true);
                    animator.SetBool("Idling", false);
                }
                else if(animalType == "DOG" && !isFollow)
                {
                    animator.SetBool("Idling", true);
                }
                animator.SetBool("Walking", false);
                
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
