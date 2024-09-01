using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class DeathState : State{
    public override void StartState(){
        anim.Play("DeathKefir");
    }
    public override void UpdateState(){ 
    }
    public override void EndState(){}
}
