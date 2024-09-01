using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class AttackManager : MonoBehaviour{
    public float damage = 10;
    public Animator anim;
    private float comboTimer = 0;
    private float attackCooldown = 0;
    private float damageCooldown = 0;
    public bool grabWeapont = false;
    [SerializeField] private VisualEffect _trailVfx;

    public AudioClip attack;
    private void Start(){
        if(grabWeapont){
            anim.Play(anim.runtimeAnimatorController.animationClips[1].name);
        }
    }
    public void GrabWeapont(){
        grabWeapont = true;
        anim.Play("PlayerIdleSword");
    }
    public void DetectedEnemy(IHealth enemy){
        if (attackCooldown <= 0){
            return;
        }

        if(damageCooldown <= 0 ){
            enemy.TakeDamage(damage);
            // damageCooldown = .1f;
        }
    }
    void Update(){
        if(!grabWeapont) return;
        if(Input.GetKeyDown(KeyCode.Mouse0) && attackCooldown <= 0){
            AudioSource.PlayClipAtPoint(attack, transform.position);
            if(comboTimer > 0){
                Attack(3);
            }else{
                Attack(2);
                comboTimer = anim.runtimeAnimatorController.animationClips[2].length + anim.runtimeAnimatorController.animationClips[4].length;
            }
        }
        comboTimer -= Time.deltaTime;
        attackCooldown -= Time.deltaTime;
        damageCooldown -= Time.deltaTime;
    }
    private void Attack(int whichAnimation){
        attackCooldown = anim.runtimeAnimatorController.animationClips[whichAnimation].length;
        anim.Play(anim.runtimeAnimatorController.animationClips[whichAnimation].name);
        
        _trailVfx.SetFloat("Duration", attackCooldown);
        _trailVfx.SendEvent("Spawn");
    }
}
