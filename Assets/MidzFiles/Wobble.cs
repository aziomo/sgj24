using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wobble : MonoBehaviour
{

    public bool shake = false;

    private bool activate = false;

    float x = 0f;
    float y = 0f;
    float z = 0f;

    private Vector3 parentPosition = Vector3.up;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (activate == true)
        {
            if (shake == false)
            {
                parentPosition = transform.parent.position;

                x += 0.01f;
                y = 0.5f * Mathf.Sin(x);

                transform.position = new Vector3(transform.position.x, parentPosition.y + y, transform.position.z);
            }
            else
            {
                parentPosition = transform.parent.position;
                y += 0.1f;
                x = 0.03f * Mathf.Sin(y);
                x = 0.03f * Mathf.Sin(y * 2);
                transform.position = new Vector3(parentPosition.x + x, transform.position.y, parentPosition.z + z);

            }
        }
    }


    public void OnSignalReceived()
    {
        Debug.Log("Signal received by ChildScript!");
        activate = true;
    }









}
