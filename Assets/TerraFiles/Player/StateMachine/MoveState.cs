using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State{
    public override void StartState(){}
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical")).normalized;
        if(inputMovement != Vector3.zero){
            Move();
        }
    }
    public override void EndState(){}
}
