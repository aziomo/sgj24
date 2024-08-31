using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;



public class NonSingletonCollision : MonoBehaviour
{
    private bool fall = false;
    private Wobble childScript;

    private Vector3 direction = Vector3.down;

    // Set desired velocity
    public Vector3 newVelocity = new Vector3(0, -1, 0);

    public float duration = 2f;





    void Start()
    {
        // Get the Rigidbody component attached to the GameObject





        

        // Method 1: Find the child by name
        Transform childTransform = transform.Find("wobbler"); // Replace with your child's name
        if (childTransform != null)
        {
            childScript = childTransform.GetComponent<Wobble>();
            if (childScript == null)
            {
                Debug.LogError("ChildScript component not found on the child object!");
            }
        }
        else
        {
            Debug.LogError("Child object not found!");
        }




    }




    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision detected");
        // Check if the collided object is the Singleton instance
        if (collision.gameObject == PlayerStats.instance.gameObject)
        {
            //Debug.Log("Collision detected with the Singleton (GameManager)!");
            // Add logic here for what should happen during the collision
            childScript.OnSignalReceived();

            StartCoroutine(Fall());
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        // If using a trigger collider
        if (other.gameObject == PlayerStats.instance.gameObject)
        {
            //Debug.Log("Trigger detected with the Singleton (GameManager)!");
            // Add logic here for what should happen during the trigger

            childScript.OnSignalReceived();

            StartCoroutine(Fall());




        }
    }
    

    private IEnumerator Fall()
    {
        float elapsedTime3 = 0f;

        while (elapsedTime3 < 2)
        {


            // Increment the elapsed time
            elapsedTime3 += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        fall = true;

        while (elapsedTime3 < 4)
        {


            // Increment the elapsed time
            elapsedTime3 += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        Destroy(gameObject);

    }


    void Update()
    {
        if (fall == true)
        {
            transform.position += direction * 2f * Time.deltaTime;
        }

    }

}