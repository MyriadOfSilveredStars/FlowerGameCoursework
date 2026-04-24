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



    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Idling", true);
        animator.SetBool("Walking", false);
        animator.SetBool("Running", false);
        animator.SetBool("Grazing", false);

        currentState = "IDLE";

        agent = GetComponent<NavMeshAgent>();

    }

    void Update()
    {
        Patrol();
    }

    public void Patrol()
    {
        if (!walkpointSet)
        {
            SearchForDestination();
        }

        if (walkpointSet)
        {
            agent.SetDestination(destinationPoint);
        }

        if(Vector3.Distance(transform.position, destinationPoint) < 10)
        {
            walkpointSet = false;
        }
    }

    public void SearchForDestination()
    {
        float z = Random.Range(-range, range); //place to move on z-axis
        float x = Random.Range(-range, range); //place to move on x-axis
        
        destinationPoint = new Vector3(transform.position.x + x, transform.position.y, transform.position.z + z);

        if(Physics.Raycast(destinationPoint, Vector3.down, groundLayer))
        {
            walkpointSet = true;
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
