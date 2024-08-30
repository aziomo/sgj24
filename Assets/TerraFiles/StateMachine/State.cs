using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour{
    protected StateMachineManager state;
    protected Rigidbody rb;
    protected GroundCheck groundCheck;
    protected PlayerStats stats;
    public bool isAction = false;
    public virtual void Awake(){
        state = GetComponent<StateMachineManager>();
        rb = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        stats = GetComponent<PlayerStats>();
    }
    public abstract void StartState();
    public abstract void UpdateState();
    public abstract void EndState();
}
