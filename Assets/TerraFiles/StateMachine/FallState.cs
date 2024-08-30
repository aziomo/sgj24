using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState: State{
    public override void StartState(){

    }
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        rb.velocity =new Vector3(inputMovement.x * stats.speed, rb.velocity.y, inputMovement.z * stats.speed);
        if(groundCheck.CheckIfOnGround()){
            state.ChangeState(States.Idle, true);
        }
    }
    public override void EndState(){

    }
}
