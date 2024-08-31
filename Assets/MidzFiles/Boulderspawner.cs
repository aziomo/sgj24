using UnityEngine;

public class SpawnBoulder : MonoBehaviour
{
    public GameObject boulderPrefab; // Reference to the Boulder prefab
    public float spawnInterval = 8f; // Time interval between spawns (in seconds)
    private float timer = 0f;

    void Update()
    {
        // Update the timer
        timer += Time.deltaTime;

        // Check if the timer has reached the spawn interval
        if (timer >= spawnInterval)
        {
            // Spawn the Boulder
            SpawnBoulderAtLocation();

            // Reset the timer
            timer = 0f;
        }
    }

    void SpawnBoulderAtLocation()
    {
        // Instantiate the Boulder at the current GameObject's position and rotation
        Instantiate(boulderPrefab, transform.position, transform.rotation);
    }
}