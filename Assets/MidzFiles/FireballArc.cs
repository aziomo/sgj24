using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MoveInArc : MonoBehaviour
{
    private List<IHealth> interactables = new List<IHealth>();

    public Transform startPoint;  // The starting point of the arc
    public Transform endPoint;    // The ending point of the arc
    public Transform controlPoint; // The control point that defines the arc's height

    public float duration = 2f;   // The time it takes to complete the arc
    private float elapsedTime = 0f;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 controlPos;
    public float timeoffset = 0f;

    public GameObject particlePrefab;

    private Collider objectCollider;

    void Start()
    {
        startPos = startPoint.position;
        endPos = endPoint.position;
        controlPos = controlPoint.position;
        elapsedTime = timeoffset;


        MonoBehaviour[] allObjects = FindObjectsOfType<MonoBehaviour>();
        foreach (MonoBehaviour obj in allObjects)
        {
            IHealth interactable = obj as IHealth;
            if (interactable != null)
            {
                interactables.Add(interactable);
            }
        }

        objectCollider = GetComponent<Collider>();

    }

    void Update()
    { 
        
        elapsedTime += Time.deltaTime;

        // Calculate the normalized time
        float t = Mathf.Clamp01(elapsedTime / duration);

        // Calculate the Bezier curve position at time t
        Vector3 currentPos = CalculateQuadraticBezierPoint(t, startPos, controlPos, endPos);

        // Set the object's position
        transform.position = currentPos;

        // If the arc is completed, stop updating the position
        if (t >= 1f)
        {
            MeshRenderer objectRenderer = GetComponent<MeshRenderer>();
            transform.position = startPos;
            elapsedTime = 0f;
            objectRenderer.enabled = true;
            objectCollider.enabled = true;
            //enabled = false;
        }
    }

    Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2)
    {
       
        return Mathf.Pow(1 - t, 2) * p0 + 2 * (1 - t) * t * p1 + Mathf.Pow(t, 2) * p2;
    }


    void OnTriggerEnter(Collider other)
    {
        // Check if the trigger is with the player
        if (other.gameObject.CompareTag("Player"))
        {
            // Disable the collider to turn off collision
            foreach (IHealth interactable in interactables)
            {
                objectCollider.enabled = false;
                interactable.TakeDamage(20);
            }

            // Make the object invisible by disabling the MeshRenderer
            MeshRenderer objectRenderer = GetComponent<MeshRenderer>();

            

            if (objectRenderer != null)
            {
                objectRenderer.enabled = false;


                if (particlePrefab != null)
                {
                    // Instantiate the particle system
                    GameObject particleInstance = Instantiate(particlePrefab, transform.position, transform.rotation);

                    // Optionally, destroy the particle system after it has finished playing
                    ParticleSystem ps = particleInstance.GetComponent<ParticleSystem>();
                    if (ps != null)
                    {
                        Destroy(particleInstance, ps.main.duration + ps.main.startLifetime.constantMax);
                    }
                }
            }


        }
    }



}