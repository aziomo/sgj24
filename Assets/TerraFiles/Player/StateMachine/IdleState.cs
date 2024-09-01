using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State{
    public float dragChange = 10;
    public override void StartState(){
        rb.drag += dragChange;
    }
    public override void UpdateState(){ 
        if(!groundCheck.CheckIfOnGround()) {
            state.ChangeState(States.Fall);
            return;
        }
    }
    public override void EndState(){
        rb.drag -= dragChange;
    }
}
