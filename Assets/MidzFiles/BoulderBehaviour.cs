using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehaviour : MonoBehaviour
{
    private Rigidbody rb;

    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply an additional force downwards equal to the gravity force
        rb.AddForce(Physics.gravity * rb.mass);

        if(transform.position.y < -30)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the trigger is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Disable the collider to turn off collision


            // Make the object invisible by disabling the MeshRenderer
            MeshRenderer objectRenderer = GetComponent<MeshRenderer>();
            if (objectRenderer != null)
            {
                objectRenderer.enabled = false;
                

            }


        }
    }
}
