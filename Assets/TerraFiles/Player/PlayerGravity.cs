using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGravity : MonoBehaviour{
    private Rigidbody rb;
    public float gravityForce = 1;
    private void Awake(){
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate(){
        rb.AddForce(gravityForce * rb.mass * Physics.gravity);
    }
}
