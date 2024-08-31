using UnityEngine;
using System.Collections.Generic;

public class AltarCutscene : MonoBehaviour
{

    public MonoBehaviour scriptToActivate;
    // List to hold the target positions as Transforms
    public List<Transform> targetTransforms = new List<Transform>();

    // Speed at which the object moves
    public float speed = 5.0f;

    //public float rotationSpeed = 2.0f;

    public bool turboreturn = false;

    // Index of the current target position
    private int currentPositionIndex = 0;

    public bool terminate = false;


    private float rememberspeed = 5.0f;


    public bool stop = false;


    void Start()
    {
        rememberspeed = speed;
    }

    void Update()
    {
        // Check if there are positions in the list
        if (targetTransforms.Count > 0)
        {
            if (turboreturn == true & currentPositionIndex == targetTransforms.Count - 2)
            {
                speed = 40f;
            }
            else
            {
                speed = rememberspeed;
            }
            // Move towards the current target position
            MoveToNextPosition();
        }
    }

    void MoveToNextPosition()
    {
        Transform targetTransform = targetTransforms[currentPositionIndex];

        // Move the object towards the target position
        transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, speed * Time.deltaTime);

        // Smoothly rotate the object towards the target rotation
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetTransform.rotation, rotationSpeed * Time.deltaTime);

        // Check if the object has reached the target position and rotation
        if (transform.position == targetTransform.position)
        {
            // Move to the next position in the list
            currentPositionIndex++;

            // If we reached the end of the list, loop back to the start
            if (currentPositionIndex >= targetTransforms.Count)
            {
                if (terminate == false)
                {
                    currentPositionIndex = 0;
                }
                else
                {
                    Destroy(gameObject);
                }


                if (stop == true)
                {
                    if (scriptToActivate != null)
                    {
                        // Activate the selected script
                        scriptToActivate.enabled = true;

                        // If the script has an "Activate" method, you can call it here
                        this.enabled = false;
                    }


                    this.enabled = false;
                }
            }
        }
    }







}