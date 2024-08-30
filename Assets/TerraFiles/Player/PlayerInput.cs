using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    private StateMachineManager states;
    private GroundCheck groundCheck;
    private PlayerStats stats;
    private void Awake(){
        states = GetComponent<StateMachineManager>();
        groundCheck = GetComponent<GroundCheck>();
        stats = GetComponent<PlayerStats>();
    }
    void Update(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"),0 , Input.GetAxisRaw("Vertical")).normalized;
        var inputJump = Input.GetAxis("Jump");
        var crouchInput = Input.GetKey(KeyCode.LeftControl);

        if(inputMovement != Vector3.zero){
            states.ChangeState(States.Move);
            RotatePlayerToMoveDirection();
        }else{
            states.ChangeState(States.Idle);
        }
        
        if(inputJump > 0 && groundCheck.CheckIfOnGround()){
            states.ChangeState(States.Jump);
        }
        
        if(crouchInput){
            transform.localScale = new Vector3(1,.3f,1);
        }else{
            transform.localScale = new Vector3(1,1,1);
        }
    }
    private void RotatePlayerToMoveDirection( ){
        var input = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical")).normalized;
        Quaternion currentRotation = GetComponent<Rigidbody>().rotation;
        Quaternion targetRotation = Quaternion.LookRotation(input.normalized);
        Quaternion smoothRotation = Quaternion.Slerp(currentRotation, targetRotation, Time.deltaTime * stats.rotationSpeed);
        GetComponent<Rigidbody>().rotation = smoothRotation;
    }
}
