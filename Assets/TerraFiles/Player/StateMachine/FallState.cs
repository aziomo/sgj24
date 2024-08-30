using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState: State{
    public float gravityChange = 20;
    public override void StartState(){
        gravity.gravityForce += gravityChange;
    }
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));
        if(inputMovement != Vector3.zero){
            Move(inputMovement);
        }

        if(groundCheck.CheckIfOnGround()){
            state.ChangeState(States.Idle, true);
        }
    }
    public override void EndState(){
        gravity.gravityForce -= gravityChange;
    }
}
