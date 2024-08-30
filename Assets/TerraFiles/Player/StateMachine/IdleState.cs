using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class IdleState : State{
    public override void StartState(){
        rb.velocity = Vector3.zero;
    }
    public override void UpdateState(){ 
        if(!groundCheck.CheckIfOnGround()) {
            state.ChangeState(States.Fall);
            return;
        }
    }
    public override void EndState(){}
}
