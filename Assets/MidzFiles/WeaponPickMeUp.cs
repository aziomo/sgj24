using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickMeUp : MonoBehaviour, IInteract
{

    private Transform player;
    float distanceToPlayer = 5f;
    float angle = 0f;


    private AttackManager attackManager;


    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.instance != null)
        {
            player = PlayerStats.instance.transform;
        }
    }

    public void Interact(){
        attackManager = player.GetComponent<AttackManager>();
        attackManager.GrabWeapont();
        Destroy(gameObject);
    }
    public GameObject GetObjectReference(){
        return gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);


        Vector3 playerForwardXZ = new Vector3(player.forward.x, 0, player.forward.z).normalized;

        // Vector from player to target in XZ plane
        Vector3 toTargetXZ = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;

        // Calculate the angle between the two vectors
        angle = Vector3.Angle(playerForwardXZ, toTargetXZ);
    }
}
