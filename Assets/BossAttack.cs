using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    private void OnTriggerEnter(Collider col){
        if(col.TryGetComponent(out IHealth player)){
            player.TakeDamage(10);
            player.TakeKnockBack(100,Vector3.up + (col.transform.position - transform.position));
        }

    }
}
