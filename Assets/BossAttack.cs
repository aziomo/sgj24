using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private float timer = 0;
    private void OnTriggerEnter(Collider col){
        if(timer <= 0 ){
            if(col.TryGetComponent(out IHealth player)){
                timer = .2f;
                player.TakeDamage(10);
                col.GetComponent<StateMachineManager>().ChangeState(States.Crouch);
                player.TakeKnockBack(100,Vector3.up + (col.transform.position - transform.position));
            }
        }
    }
    private void Update(){
        timer -= Time.deltaTime;
    }
}
