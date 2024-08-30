using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoController : MonoBehaviour
{
    
    public GameObject lasso;
    
    public float throwDistance = 5f;

    private bool isFlying = false;

    public float speed = 5f;

    private float timeThrowBegin = -1;


    private Quaternion angleThrownAt;
    private Vector3 positionThrownAt;


    void Start()
    {
        lasso = GameObject.Find("Lasso");
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFlying = true;
            timeThrowBegin = Time.fixedTime;
            angleThrownAt = transform.rotation;
            positionThrownAt = transform.position;
            lasso.GetComponent<MeshRenderer>().enabled = true;
        }

        if (isFlying)
        {
            var distanceTravelled = (Time.fixedTime - timeThrowBegin) * speed;

            float height = (float) Math.Sin((distanceTravelled / throwDistance) * Math.PI) * 2.0f;

            var deltaVector = angleThrownAt * new Vector3(0, height, distanceTravelled);

            lasso.transform.position = positionThrownAt + deltaVector;

            if (distanceTravelled > throwDistance) {
                isFlying = false;
                lasso.transform.position = transform.position;
                lasso.GetComponent<MeshRenderer>().enabled = false;
            }
        }

    }
}
