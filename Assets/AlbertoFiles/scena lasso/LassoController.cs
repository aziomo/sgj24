using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoController : MonoBehaviour
{
    
    public GameObject lasso;
    public GameObject lassoHoop;
    
    public float throwDistance = 15f;
    private bool isFlying = false;
    public float speed = 20f;
    private float timeThrowBegin = -1;

    private Quaternion angleThrownAt;
    private Vector3 positionThrownAt;

    private Vector3 lassoStartOffset = new Vector3(1, 0.25f, 0.1f);

    public bool cowOnLasso = false;
    public Transform caughtCow = null;


    void Start()
    {
        lasso.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lasso.SetActive(true);
            isFlying = true;
            timeThrowBegin = Time.fixedTime;
            angleThrownAt = transform.rotation;
            positionThrownAt = transform.position + new Vector3(1f, 0, 0);
        }

        if (caughtCow != null) 
        {
            lassoHoop.transform.position = caughtCow.transform.position + new Vector3(0, 2, 0);
        } 
        else if (isFlying)
        {
            var distanceTravelled = (Time.fixedTime - timeThrowBegin) * speed;
            float height = (float) Math.Sin((distanceTravelled / throwDistance) * Math.PI) * 2.0f;
            var deltaVector = angleThrownAt * new Vector3(0, height, distanceTravelled);
            lassoHoop.transform.position = positionThrownAt + deltaVector;


            // if (caughtCow != null) {
            //     lassoHoop.transform.position = caughtCow.transform.position;
            // } else 
            if (distanceTravelled > throwDistance)
            {
                isFlying = false;
                lassoHoop.transform.position = transform.position;
                lasso.SetActive(false);
            }
        }

    }
}
