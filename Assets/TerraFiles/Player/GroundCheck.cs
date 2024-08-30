using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour{
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float distance = .1f;
    [SerializeField] private LayerMask ground;
    public bool CheckIfOnGround(){
        return Physics.Raycast(groundCheck.position,Vector2.down, distance, ground);
    }
}
