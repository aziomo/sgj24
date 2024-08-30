using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState: State{
    public override void StartState(){

    }
    public override void UpdateState(){
        if(groundCheck.CheckIfOnGround()){
            state.ChangeState(States.Idle, true);
        }
    }
    public override void EndState(){

    }
}
