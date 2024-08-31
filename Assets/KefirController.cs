using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KefirController : MonoBehaviour
{
    public Transform player;

    public float speed = 5.0f; 

    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        
    }

    void Update()
    {
        agent.SetDestination(player.position);
    }
}
