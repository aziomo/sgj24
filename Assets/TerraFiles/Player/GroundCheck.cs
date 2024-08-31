using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float radius = .1f;
    [SerializeField] private LayerMask ground;
    public bool CheckIfOnGround(){
        return Physics.OverlapSphere(groundCheck.position, radius, ground).Length > 0;
    }
    private void OnDrawGizmosSelected(){
        if (groundCheck != null){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, radius);
        }
    }
}
