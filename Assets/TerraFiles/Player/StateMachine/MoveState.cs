using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : State{
    public ParticleSystem particleRun;
    private void Start(){
        particleRun.Stop();
    }
    public override void StartState(){}
    public override void UpdateState(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical")).normalized;
        if(inputMovement != Vector3.zero){
            Move();
        }
    }
    public override void EndState(){
        particleRun.Stop();
    }
    public override void Move(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
        if(Input.GetKey(KeyCode.LeftShift)){
            if(particleRun.isStopped)
                particleRun.Play();
            UltimateCamera.instance.StartCameraShake(.1f, 10);
            rb.velocity =new Vector3(inputMovement.x * stats.speed * stats.sprintMultiplier, rb.velocity.y, inputMovement.z * stats.speed* stats.sprintMultiplier);
        }else{
            particleRun.Stop();
            rb.velocity =new Vector3(inputMovement.x * stats.speed, rb.velocity.y, inputMovement.z * stats.speed);
        }
    }
}
