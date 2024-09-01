using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RollingBossState : State{
    public ParticleSystem fallParticle;
    private Transform atckPosition;
    public Transform[] attackPlaces;
    public float speed = 1;
    private bool calledEndAttacck = false;
    public override void StartState(){
        fallParticle.Stop();
        atckPosition = attackPlaces[Random.Range(0, attackPlaces.Length)];
    }
    public override void UpdateState(){
        if(Vector3.Distance(atckPosition.position, transform.position) > 5f){
            transform.parent.GetComponent<NavMeshAgent>().SetDestination(new Vector3(atckPosition.position.x, transform.position.y, atckPosition.position.z));
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
