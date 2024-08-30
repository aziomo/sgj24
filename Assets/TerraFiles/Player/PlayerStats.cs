using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour,IHealth{
    public static PlayerStats instance;
    public float speed = 1;
    public float sprintMultiplier = 2;
    public float jumpForce = 2;
    public float health = 100;
    private void Awake(){
        instance = this;
    }
    public void TakeDamage(float damage){
        health -= damage;
    }
    public void TakeHeal(float heal){
        health += heal;
    }
}
