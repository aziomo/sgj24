using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour, IHealth{
    public float hp = 100;
    [SerializeField] private GameObject _splashVfx;
    [SerializeField] private GameObject _deathVfx;
    public void TakeDamage(float damage){
        hp -= damage;
        if(hp <= 0){
            StartCoroutine(DeathKerfus());
        }
        else
        {
            Instantiate(_splashVfx, Sausage.Active.transform.position, Quaternion.identity);
        }
    }
    private IEnumerator DeathKerfus(){
        enabled = false;
        GetComponent<StateMachineManager>().ChangeState(States.Death, true);
        var anim = GetComponent<Animator>();
        yield return new WaitForSeconds(anim.runtimeAnimatorController.animationClips[5].length + anim.runtimeAnimatorController.animationClips[6].length);
        GameManager.Instance.ConditionCalled();
        Instantiate(_deathVfx, transform.position, Quaternion.identity);
    }
    public void TakeKnockBack(float force ,Vector3 dir){}
    public void TakeHeal(float heal){}

}
