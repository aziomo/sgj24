using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{

    [SerializeField] private int health;


    void Start()
    {
    }

    void Update()
    {
    }

    public void TakeDamage(float x) {
        health -= (int)x;
        if (health < 0) {
            gameObject.GetComponent<WalkerController>().isDying = true;
            Destroy(gameObject, 3f);
        }
    }

    public void TakeHeal(float x) {
        health += (int)x;
    }

    private void OnTriggerEnter(Collider other) {
        
    }

}
