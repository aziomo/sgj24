using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEndLevel2 : MonoBehaviour{
    private void OnTriggerEnter(Collider col){
        if(col.TryGetComponent(out PlayerStats playerStats)){
            GameManager.Instance.ConditionCalled();
        }
    }
}
