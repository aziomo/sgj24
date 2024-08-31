using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private Transform player;

    float distanceToPlayer = 5f;

    public MonoBehaviour scriptToActivate;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerStats.instance != null)
        {
            player = PlayerStats.instance.transform;
        }
        else
        {
            Debug.LogError("PlayerStats singleton instance not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.position);


        Vector3 playerForwardXZ = new Vector3(player.forward.x, 0, player.forward.z).normalized;

        // Vector from player to target in XZ plane
        Vector3 toTargetXZ = new Vector3(transform.position.x - player.position.x, 0, transform.position.z - player.position.z).normalized;

        if (distanceToPlayer <= 8)
        {
            if (scriptToActivate != null)
            {
                // Activate the selected script
                scriptToActivate.enabled = true;

                // If the script has an "Activate" method, you can call it here
                this.enabled = false;
            }
        }



    }

    
}
