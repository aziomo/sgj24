using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State{
    public override void StartState(){
        rb.velocity = new Vector3(rb.velocity.x, stats.jumpForce, rb.velocity.z);
    }
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical")).normalized;
        if(inputMovement != Vector3.zero){
            Move();
        }
        if(rb.velocity.y < 0 || rb.velocity.y < 0 && groundCheck.CheckIfOnGround()){
            state.ChangeState(States.Fall, true);
        }
    }
    public override void EndState(){}
}
