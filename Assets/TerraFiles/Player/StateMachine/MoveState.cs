using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State{
    public override void StartState(){}
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));

        Move(inputMovement);
    }
    public override void EndState(){}
}
