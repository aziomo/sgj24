using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class RollingBossState : State{
    public ParticleSystem fallParticle;
    public Transform atckPosition;
    public float speed = 1;
    private bool calledEndAttacck = false;
    public override void StartState(){
        fallParticle.Stop();
    }
    public override void UpdateState(){
        if(Vector3.Distance(atckPosition.position, transform.position) > 5f){
            transform.parent.position = Vector3.MoveTowards(transform.parent.position, 
                new Vector3(atckPosition.position.x, transform.position.y, atckPosition.position.z), 
            speed * Time.deltaTime);
        }else if(!calledEndAttacck){
            calledEndAttacck = true;
            StartCoroutine(IDK());
        }
    }
    private IEnumerator IDK(){
        anim.Play("FallKefir");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[2].length);
        fallParticle.Play();
        UltimateCamera.instance.StartCameraShake(.6f, 50);
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[3].length + anim.runtimeAnimatorController.animationClips[4].length);
        state.ChangeState(States.BossIdle);
    }
    public override void EndState(){}
}
