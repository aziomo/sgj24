using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheckPlayerTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the tag "Player"
        if (other.CompareTag("Player"))
        {

            Destroy(gameObject);
            // Perform the action you want when the player enters the trigger
            Debug.Log("Player has entered the trigger!");

            // You can add additional logic here, such as:
            // - Destroying the object
            // - Triggering an event
            // - Changing a variable, etc.
        }
    }
}
