using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SwordTrigger : MonoBehaviour{
    public GameObject player;
    private void OnTriggerEnter(Collider enemy){
        if(enemy.TryGetComponent<IHealth>(out var health)){
            player.GetComponent<AttackManager>().DetectedEnemy(health);
        }
    }
}
