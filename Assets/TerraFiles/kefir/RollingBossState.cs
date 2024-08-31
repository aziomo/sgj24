using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class RollingBossState : State{
    public ParticleSystem fallParticle;
    public override void StartState(){
        fallParticle.Stop();
        StartCoroutine(IDK());
    }
    public override void UpdateState(){}
    private IEnumerator IDK(){
        anim.Play("FallKefir");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[2].length);
        fallParticle.Play();
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[3].length + anim.runtimeAnimatorController.animationClips[4].length);
        state.ChangeState(States.BossIdle);
    }
    public override void EndState(){}
}
