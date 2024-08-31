using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class FollowBossState : State{
    private Transform target;
    public ParticleSystem jumpParticle;
    public float speed = 1;
    private float timer = 0;
    private float yPosition = 0;
    private void Start(){
        yPosition = transform.position.y;
    }
    public override void StartState(){
        target = PlayerStats.instance.transform;
        jumpParticle.Stop();
        timer = anim.runtimeAnimatorController.animationClips[1].length * Random.Range(3, 6);
        StartCoroutine(IDK());
        StartCoroutine(IDK2(timer));

    }
    private IEnumerator IDK(){
        anim.Play("JumpKefir");
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[1].length- .3f);
        jumpParticle.Play();
        UltimateCamera.instance.StartCameraShake(.6f, 50);
        yield return new WaitForSeconds(.3f);
        timer -= anim.runtimeAnimatorController.animationClips[1].length;
        if(timer > 0){
            StartCoroutine(IDK());
        }
    }
    private IEnumerator IDK2(float timer){
        yield return new WaitForSeconds(timer);
        state.ChangeState(States.BossIdle);
    }
    public override void UpdateState(){ 
        var targetPosition = new Vector3(target.position.x,yPosition, target.position.z);
        transform.parent.position = Vector3.MoveTowards(transform.parent.position, targetPosition, speed * Time.deltaTime);
    }
    public override void EndState(){}
}
