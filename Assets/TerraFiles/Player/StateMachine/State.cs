using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour{
    protected StateMachineManager state;
    protected Rigidbody rb;
    protected GroundCheck groundCheck;
    protected PlayerStats stats;
    protected PlayerGravity gravity;
    protected Animator anim;
    public bool isAction = false;
    public virtual void Awake(){
        state = GetComponent<StateMachineManager>();
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        stats = GetComponent<PlayerStats>();
        gravity = GetComponent<PlayerGravity>();
        anim = GetComponent<Animator>();
    }
    public abstract void StartState();
    public abstract void UpdateState();
    public abstract void EndState();
    public virtual void Move(){
        var inputMovement = new Vector3(Input.GetAxisRaw("Horizontal"), 0 , Input.GetAxisRaw("Vertical"));
        if(Input.GetKey(KeyCode.LeftShift)){
            rb.velocity =new Vector3(inputMovement.x * stats.speed * stats.sprintMultiplier, rb.velocity.y, inputMovement.z * stats.speed* stats.sprintMultiplier);
        }else{
            rb.velocity =new Vector3(inputMovement.x * stats.speed, rb.velocity.y, inputMovement.z * stats.speed);
        }
    }
}
