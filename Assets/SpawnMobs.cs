using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpawnMobs : MonoBehaviour
{

    [SerializeField] private GameObject spawnedMob;
    [SerializeField] private GameObject player;
    [SerializeField] private float spawnFreq = 0.5f;
    [SerializeField] private int maxEnemiesCount = 10;

    List<Enemy> enemies = new List<Enemy>();

    
    public static int enemiesCount = 0;


    float nextSpawnIn;

    void Start()
    {
        nextSpawnIn = spawnFreq;
    }


    void Update()
    {
        foreach (Enemy enemy in enemies.ToList())
        {
            if (enemy.health <= 0) {
                enemies.Remove(enemy);
            }
        }


        if (enemies.Count >= maxEnemiesCount) {
            return;
        }

        nextSpawnIn -= Time.deltaTime;
        if (nextSpawnIn < 0) {
            foreach (Transform child in transform){
                var instance = Instantiate(spawnedMob, child.position, Quaternion.identity);
                var walkerController = instance.GetComponent<WalkerController>();
                var enemy = instance.GetComponent<Enemy>();
                walkerController.player = player.transform;
                nextSpawnIn = spawnFreq;
                enemies.Add(enemy);
            }
        }
    }
    
}
