using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineManager : MonoBehaviour{
    [SerializeField] private List<State> states = new();
    [SerializeField] private State currentState;
    private float timer = 0;
    private void Start(){
        currentState = states[0];
        currentState.StartState();
    }
    public void ChangeState(States newState, bool force = false){
        if((currentState == GetState(newState)) || (currentState.isAction && !force)) return;
        if(timer < Time.time){
            currentState.EndState();
            currentState = GetState(newState);
            currentState.StartState();
            timer = Time.time + .01f;
        }
    }
    private void Update(){
        currentState.UpdateState();
    }

    private State GetState(States state){
        return state switch{
            States.Idle => states[0],
            States.Move => states[1],
            States.Crouch => states[2],
            States.Jump => states[3],
            States.Fall => states[4],
            _ => states[0],
        };
    }
}
public enum States{
    Idle,
    Move,
    Crouch,
    Jump,
    Fall
}