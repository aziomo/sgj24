using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoulderBehaviour : MonoBehaviour
{
    private List<IHealth> interactables = new List<IHealth>();

    private Rigidbody rb;

    public GameObject particlePrefab;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        MonoBehaviour[] allObjects = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour obj in allObjects)
        {
            IHealth interactable = obj as IHealth;
            if (interactable != null)
            {
                interactables.Add(interactable);
            }
        }

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

            foreach (IHealth interactable in interactables)
            {
                interactable.TakeDamage(40);
            }



            Vector3 collisionPoint = collision.contacts[0].point;
            Quaternion collisionRotation = Quaternion.identity;

            // Instantiate the particle system at the collision point
            GameObject particleInstance = Instantiate(particlePrefab, collisionPoint, collisionRotation);

            // Optionally, destroy the particle system after it has finished playing
            ParticleSystem ps = particleInstance.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                Destroy(particleInstance, ps.main.duration + ps.main.startLifetime.constantMax);
            }





            // Make the object invisible by disabling the MeshRenderer
            MeshRenderer objectRenderer = GetComponent<MeshRenderer>();
            if (objectRenderer != null)
            {
                objectRenderer.enabled = false;
                

            }


        }
    }
}
