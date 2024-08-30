using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State{
    public override void StartState(){
        rb.AddForce(stats.jumpForce * 100 * Vector3.up);
    }
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(inputMovement != Vector3.zero){
            Move(inputMovement);
        }
        
        if(rb.velocity.y < 0 || rb.velocity.y < 0 && groundCheck.CheckIfOnGround()){
            state.ChangeState(States.Fall, true);
        }
    }
    public override void EndState(){}
}
