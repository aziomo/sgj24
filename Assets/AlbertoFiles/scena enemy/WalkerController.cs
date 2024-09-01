using UnityEngine;
using UnityEngine.AI;

public class WalkerController : MonoBehaviour
{

    public float rotationSpeed = 10.0f;
    public Transform player;
    
    public float speed = 5.0f; // Set the speed you want your object to move at
    public bool isDying = false;

    [SerializeField] private NavMeshAgent agent;
    // private Collider pathPointsCollider;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        if (player) {
            agent.SetDestination(player.position);
        }
    }

    public bool IsPointWithinCollider(Collider collider, Vector3 point) {
        return (collider.ClosestPoint(point) - point).sqrMagnitude < Mathf.Epsilon * Mathf.Epsilon;
    }

    public void SetDestinationToPlayer() {
        agent.SetDestination(player.position);
    }

    void Update()
    {
        if (isDying) {
            agent.enabled = false;
            // print("halo");
            transform.position = transform.position + new Vector3(0, 20f * Time.deltaTime, 0);
        } else if (player) {
            agent.SetDestination(player.position);
        }
    }

}
