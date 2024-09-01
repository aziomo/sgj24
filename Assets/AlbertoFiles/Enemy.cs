using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{

    [SerializeField] public int health;


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
            SpawnMobs.enemiesCount--;
            Destroy(gameObject, 3f);
        }
    }

    public void TakeHeal(float x) {
        health += (int)x;
    }

    private void OnTriggerEnter(Collider other) {
        
    }

}
