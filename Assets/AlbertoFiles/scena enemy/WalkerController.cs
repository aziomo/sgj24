using UnityEngine;
using UnityEngine.AI;

public class WalkerController : MonoBehaviour
{

    // public LineRenderer path;
    public float rotationSpeed = 10.0f;

    public Transform[] patrolPath;
    private int pathPointCounter = 0;
    
    public float speed = 5.0f; // Set the speed you want your object to move at

    private NavMeshAgent agent;
    private Collider pathPointsCollider;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed; // Set the agent's speed
        agent.SetDestination(patrolPath[pathPointCounter].position); 
        pathPointsCollider = GetComponent<CapsuleCollider>();
    }

    public bool IsPointWithinCollider(Collider collider, Vector3 point) { 
        return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon; 
    }

    void Update()
    {

        if (IsPointWithinCollider(pathPointsCollider, patrolPath[pathPointCounter].position)){
            pathPointCounter += 1;
            if (pathPointCounter == patrolPath.Length){
                pathPointCounter = 0;
            }
            agent.SetDestination(patrolPath[pathPointCounter].position); 
        }

    }

}
