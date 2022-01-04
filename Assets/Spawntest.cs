using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawntest : MonoBehaviour
{
    public float spawnTime = 5f; // The amount of time between each spawn.
    public float spawnDelay = 3f; // The amount of time before spawning starts.
    public float chanceSpawnRare = 0.1f; // Chance that a rare enemy will spawn.
    public GameObject[] normalEnemies; // Array of regular enemy prefabs.
    public GameObject[] rareEnemies; // Array of the rare enemy prefabs.

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay.
       InvokeRepeating("Spawn", spawnDelay, spawnTime);

    }

    GameObject[] spawnArray;
    int enemyIndex;

    void Spawn()
    {
        // Chance to spawn rare, or normal enemies.
        if (Random.Range(0f, 1f) > chanceSpawnRare)
        {
            spawnArray = normalEnemies;
        }
        else
        {
            spawnArray = rareEnemies;
        }

        // Instantiate an enemy.
        enemyIndex = Random.Range(0, spawnArray.Length);
        Instantiate(spawnArray[enemyIndex], transform.position, transform.rotation);
    }
}
