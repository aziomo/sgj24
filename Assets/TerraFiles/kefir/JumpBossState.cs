using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class JumpBossState : State{
    public ParticleSystem jumpParticle;
    public override void StartState(){
        jumpParticle.Stop();
        StartCoroutine(IDK());
    }
    public override void UpdateState(){}
    private IEnumerator IDK(){
        anim.Play("JumpKefir");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length- .3f);
        jumpParticle.Play();
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length);
        state.ChangeState(States.BossIdle);
    }
    public override void EndState(){}
}
