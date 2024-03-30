using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public List<Transform> waypoints;
    public float spawnInterval = 2f; // Time between each spawn
    private float timeSinceLastSpawn;

    void Start()
    {
        timeSinceLastSpawn = 0; // Initialize timer
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime; // Update the spawn timer

        // Check if it's time to spawn another enemy
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnEnemy();
            timeSinceLastSpawn = 0; // Reset timer
        }
    }

    void SpawnEnemy()
    {
        // Instantiate the enemy
        GameObject spawnedEnemy = Instantiate(objectToSpawn, transform.position, Quaternion.identity);
        
        // Assuming the enemy script is named EnemyMovement as per your code
        EnemyMovement enemyMovement = spawnedEnemy.GetComponent<EnemyMovement>();

        // Check if the spawned object has the EnemyMovement script
        if(enemyMovement != null)
        {
            // Assign the waypoints list to the spawned enemy
            enemyMovement.waypoints = waypoints;
        }
        else
        {
            Debug.LogError("Spawned object does not have an EnemyMovement component.");
        }
    }
}
