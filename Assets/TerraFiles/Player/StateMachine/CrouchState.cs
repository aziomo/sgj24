using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrouchState : State{
    public float stateTime = 1;
    public override void StartState(){ 
        StartCoroutine(ChangeState());
    }
    private IEnumerator ChangeState(){
        yield return new WaitForSeconds(stateTime);
        state.ChangeState(States.Idle);
    }
    public override void UpdateState(){}
    public override void EndState(){}
}
