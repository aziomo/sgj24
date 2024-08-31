using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackManager : MonoBehaviour{
    public float damage = 10;
    public Animator anim;
    private float comboTimer = 0;
    private float attackCooldown = 0;
    void Update(){
        if(Input.GetKeyDown(KeyCode.Mouse0) && attackCooldown <= 0){
            if(comboTimer > 0){
                Attack(3);
            }else{
                Attack(2);
                comboTimer = anim.runtimeAnimatorController.animationClips[2].length + anim.runtimeAnimatorController.animationClips[4].length;
            }
        }
        comboTimer-= Time.deltaTime;
        attackCooldown -= Time.deltaTime;
    }
    private void Attack(int whichAnimation){
        attackCooldown = anim.runtimeAnimatorController.animationClips[whichAnimation].length;
        anim.Play(anim.runtimeAnimatorController.animationClips[whichAnimation].name);
    }
}
