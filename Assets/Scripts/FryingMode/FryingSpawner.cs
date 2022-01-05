using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryingSpawner : MonoBehaviour
{
    public GameObject[] fruitPrefabs;
    GameObject[] SpawnArray;
    public GameObject[] rareObjects;
    public Transform SpawnPoint;
    public float time = .1f;
    public float delay = 1f;
    public float rarity;

    int SpawnIndex;

    private void Start()
    {
        InvokeRepeating("Spawn", delay, time);
    }

    public void Spawn()
    {
        if (Random.Range(0f, 1f) > rarity) 
        {
            SpawnArray = fruitPrefabs;
        }
        else
        {
            SpawnArray = rareObjects;
        }

        SpawnIndex = Random.Range(0, SpawnArray.Length);
        Instantiate(SpawnArray[SpawnIndex], SpawnPoint.position, SpawnPoint.rotation);

    }
}