using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{

    public bool shake = false;

    public bool activate = false;

    float x = 0f;
    float y = 0f;
    float z = 0f;


    Vector3 currentLocalPosition = Vector3.up;

    Vector3 rememberLocalPosition = Vector3.up;

    // Start is called before the first frame update
    void Start()
    {
        currentLocalPosition = transform.localPosition;
        rememberLocalPosition = currentLocalPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            if (shake == false)
            {
                

                x += 0.01f;
                y = 0.2f * Mathf.Sin(x);



                currentLocalPosition.y = rememberLocalPosition.y + y;

                // Apply the new local position back to the GameObject
                transform.localPosition = currentLocalPosition;
            }
            else
            {
                
                y += 0.1f;
                x = 0.03f * Mathf.Sin(y);
                currentLocalPosition.x = rememberLocalPosition.x + x;
                z = 0.03f * Mathf.Sin(y * 2);
                currentLocalPosition.z = rememberLocalPosition.z + z;
                transform.localPosition = currentLocalPosition;

            }
        }
    }


    public void OnSignalReceived()
    {
        Debug.Log("Signal received by ChildScript!");
        activate = true;
    }









}
