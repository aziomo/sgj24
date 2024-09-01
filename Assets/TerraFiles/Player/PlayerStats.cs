using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour,IHealth{
    public static PlayerStats instance;
    public float speed = 1;
    public float sprintMultiplier = 2;
    public float jumpForce = 2;
    public float health = 100;
    public float rotationSpeed = 40;
    [SerializeField] private GameObject _bloodVfx;
    public Slider slider;
    private void Awake(){
        instance = this;
    }
    public void TakeDamage(float damage){
        health -= damage;
        slider.value = health / 100;
        if(health <= 0){
            GameManager.Instance.ResetLevel();
        }
        else{
            Instantiate(_bloodVfx, transform.position, Quaternion.identity);
        }
    }
    public void TakeKnockBack(float force ,Vector3 dir){
        GetComponent<Rigidbody>().velocity = dir*force;
    }
    public void TakeHeal(float heal){
        health += heal;
    }
}
