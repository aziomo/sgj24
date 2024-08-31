using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateMachine : StateMachineManager{
    protected override State GetState(States state){
        return state switch{
            States.BossIdle => states[0],
            States.BossJumpAttack => states[1],
            States.BossRolling => states[2],
            _ => states[0],
        };
    }
}
