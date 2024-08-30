using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : State{
    public override void StartState(){ 
        state.ChangeState(States.Idle);
    }
    public override void UpdateState(){}
    public override void EndState(){}
}
