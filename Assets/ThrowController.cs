using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    
    public GameObject lasso;
    
    
    public float throwDistance = 10f;

    private bool isFlying = false;

    public float speed = 5f;

    private float timeThrowBegin = -1;


    private Quaternion angleThrownAt;
    private Vector3 positionThrownAt;



    // Start is called before the first frame update
    void Start()
    {
        lasso = GameObject.Find("Lasso");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFlying = true;
            timeThrowBegin = Time.fixedTime;
            angleThrownAt = transform.rotation;
            positionThrownAt = transform.position;
        }

        if (isFlying)
        {
            var distanceTravelled = (Time.fixedTime - timeThrowBegin) * speed;

            var deltaVector = angleThrownAt * new Vector3(distanceTravelled, 0, distanceTravelled);

            lasso.transform.position = transform.position + deltaVector;

            if (distanceTravelled > throwDistance) {
                isFlying = false;
                lasso.transform.position = transform.position;
            }
        }

    }
}
