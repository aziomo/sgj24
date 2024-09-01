using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{

    [SerializeField] private GameObject spawnedMob;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnFreq = 0.5f;
    

    float nextSpawnIn;

    void Start()
    {
        nextSpawnIn = spawnFreq;
    }

    void Update()
    {
        nextSpawnIn -= Time.deltaTime;
        if (nextSpawnIn < 0) {
            var instance = Instantiate(spawnedMob, gameObject.transform.position, Quaternion.identity);
            // instance.transform.position = transform.position;
            var walkerController = instance.GetComponent<WalkerController>();
            walkerController.player = player.transform;

            nextSpawnIn = spawnFreq;
        }
    }
    
}
