using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpState : State{
    public override void StartState(){
        rb.AddForce(stats.jumpForce * 100 * Vector3.up);
    }
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        rb.velocity =new Vector3(inputMovement.x * stats.speed, rb.velocity.y, inputMovement.z * stats.speed);
        
        if(rb.velocity.y <= 0){
            state.ChangeState(States.Fall, true);
        }
    }
    public override void EndState(){}
}
