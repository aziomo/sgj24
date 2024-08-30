using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour{
    [Header("Player Stats")]
    [SerializeField] private float speed = 1;
    [SerializeField] private float jumpForce = 1;
     [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float distance = .1f;
    [SerializeField] private LayerMask ground;
    private Rigidbody rb;
    private float timer;
    void Start(){
        rb = GetComponent<Rigidbody>();
    }
    void Update(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
        var inputJump = Input.GetAxis("Jump");

        RotatePlayerToMoveDirection(inputMovement);
        Move(inputMovement);
        if(CheckIfOnGround() && inputJump > 0 && timer < 0){Jump();}

        timer -= Time.deltaTime;
    }
    private void Move(Vector3 input){
        if(CheckIfOnGround() || input != Vector3.zero){
            rb.velocity = new Vector3(input.x * speed, rb.velocity.y, input.z * speed);
        }else if(input != Vector3.zero){
            rb.velocity = new Vector3(input.x * speed, rb.velocity.y, input.z * speed);
        }else if(rb.velocity.y < 0){
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,rb.velocity.z);
        }
    }
    private void Jump(){
        timer = .5f;
        rb.AddForce(100 * jumpForce * Vector3.up);
    }
    private void RotatePlayerToMoveDirection(Vector3 input){
        if(input == Vector3.zero)return;
        rb.rotation = Quaternion.LookRotation(input.normalized);
    }
    private bool CheckIfOnGround(){
        return Physics.Raycast(groundCheck.position,Vector2.down, distance, ground);
    }
}
public enum PlayerState{
    Idle,
    Move,
    Jump,
    Fall
}
