using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    private StateMachineManager states;
    private GroundCheck groundCheck;
    private void Awake(){
        states = GetComponent<StateMachineManager>();
        groundCheck = GetComponent<GroundCheck>();
    }
    void Update(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"),0 , Input.GetAxis("Vertical"));
        var inputJump = Input.GetAxis("Jump");
        
        RotatePlayerToMoveDirection(inputMovement);

        if(inputMovement != Vector3.zero){
            states.ChangeState(States.Move);
        }else{
            states.ChangeState(States.Idle);
        }
        
        if(inputJump > 0 && groundCheck.CheckIfOnGround()){
            states.ChangeState(States.Jump);
        }
    }
     private void RotatePlayerToMoveDirection(Vector3 input){
        if(input == Vector3.zero)return;
        GetComponent<Rigidbody>().rotation = Quaternion.LookRotation(input.normalized);
    }
}
