using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBossState : State{
    public float timeBetweenAttacksMin = 1f;
    public float timeBetweenAttacksMax = 5f;
    private float timer = 0;
    public States[] attackList;
    public override void StartState(){
        anim.CrossFade("IdleKefir", 0);
        timer = Time.time + Random.Range(timeBetweenAttacksMin, timeBetweenAttacksMax);
    }
    public override void UpdateState(){ 
        if(timer < Time.time){
            state.ChangeState(attackList[Random.Range(0, attackList.Length)]);
        }
    }
    public override void EndState(){}
}
