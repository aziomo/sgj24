using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class JumpBossState : State{
    public ParticleSystem jumpParticle;
    public AudioClip hitGround;
    public override void StartState(){
        jumpParticle.Stop();
        StartCoroutine(IDK());
    }
    public override void UpdateState(){}
    private IEnumerator IDK(){
        anim.Play("JumpKefir");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length - .3f);
        jumpParticle.Play();
        UltimateCamera.instance.StartCameraShake(.6f, 50);
        AudioSource.PlayClipAtPoint(hitGround, transform.position);
        yield return new WaitForSeconds(.3f);
        state.ChangeState(States.BossIdle);
    }
    public override void EndState(){}
}
