using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHP : MonoBehaviour, IHealth{
    public float hp = 100;
    public void TakeDamage(float damage){
        hp -= damage;
        Debug.Log("deal damage");
    }
    public void TakeHeal(float heal){

    }

}
