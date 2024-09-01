using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowBossState : State{
    private Transform target;
    public ParticleSystem jumpParticle;
    public AudioClip hitGround;
    private float timer = 0;
    private float yPosition = 0;
    private Camera camera;
    private void Start(){
        yPosition = transform.position.y;
        camera = GameObject.FindFirstObjectByType<Camera>();
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
        AudioSource.PlayClipAtPoint(hitGround, camera.transform.position, 0.3f);
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
        transform.parent.GetComponent<NavMeshAgent>().SetDestination(targetPosition);
    }
    public override void EndState(){}
}
