using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState: State{
    public float gravityChangeSpeed = 20;
    public float addGravity = 2;
    private float maxGravity = 1f;
    private float startGravity = 1f;
    public override void StartState(){
        startGravity = gravity.gravityForce;
        maxGravity = gravity.gravityForce + addGravity;
    }
    public override void UpdateState(){
        if(maxGravity > gravity.gravityForce){
            gravity.gravityForce += Time.deltaTime * gravityChangeSpeed;
        }
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical")).normalized;
        if(inputMovement != Vector3.zero){
            Move();
        }

        if(groundCheck.CheckIfOnGround()){
            state.ChangeState(States.Idle, true);
        }
    }
    public override void EndState(){
        gravity.gravityForce = startGravity;
    }
}
