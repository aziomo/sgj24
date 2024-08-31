using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LassoController : MonoBehaviour
{
    
    public GameObject lasso;
    // public GameObject lassoPrefab;
    
    public float throwDistance = 5f;

    private bool isFlying = false;

    public float speed = 5f;

    private float timeThrowBegin = -1;


    private Quaternion angleThrownAt;
    private Vector3 positionThrownAt;

    private Vector3 lassoStartOffset = new Vector3(1, 0.25f, 0.1f);

    public GameObject lassoHoop;

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

        if (isFlying)
        {
            var distanceTravelled = (Time.fixedTime - timeThrowBegin) * speed;
            float height = (float) Math.Sin((distanceTravelled / throwDistance) * Math.PI) * 2.0f;
            var deltaVector = angleThrownAt * new Vector3(0, height, distanceTravelled);
            lassoHoop.transform.position = positionThrownAt + deltaVector;

            if (distanceTravelled > throwDistance)
            {
                isFlying = false;
                lassoHoop.transform.position = transform.position;
                lasso.SetActive(false);
            }
        }

    }
}
