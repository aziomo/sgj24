using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour, IHealth{
    public float hp = 100;
    public void TakeDamage(float damage){
        hp -= damage;
        if(hp <= 0){
            // tu enumerator do animacji śmierci kerfusia
            GameManager.Instance.ConditionCalled();
        }
    }
    public void TakeHeal(float heal){}

}
