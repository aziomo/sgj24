using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{

    public float speed = 3.0f;
    public Quaternion projectileDirection;

    void Start()
    {
        transform.Rotate(-90, 0, 0);
    }

    void Update()
    {
        transform.position += projectileDirection * new Vector3(0, 0, speed * Time.deltaTime);
    }
}
