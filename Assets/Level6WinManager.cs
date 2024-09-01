using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level6WinManager : MonoBehaviour{
    public float timer = 300;
    void Update(){
        timer -= Time.deltaTime;
        if(timer <= 0 ){
            GameManager.Instance.ConditionCalled();
        }
    }
}
