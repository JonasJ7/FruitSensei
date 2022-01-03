using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;

    int spawnIndex;
    Transform spawnPoint;
    public float rotateSpeed = 15f;

    public void Spawn(GameObject fruit) {
        float delay = Random.Range(minDelay, maxDelay);
        spawnIndex = Random.Range(0, spawnPoints.Length);
        spawnPoint = spawnPoints[spawnIndex];

        GameObject spawnedFruit = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
        Destroy(spawnedFruit, 5f);
    }


    void Update() {
        foreach (Transform spawnPoint in spawnPoints)
        {
            spawnPoint.transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, 80) - 45);
        }
    }
}