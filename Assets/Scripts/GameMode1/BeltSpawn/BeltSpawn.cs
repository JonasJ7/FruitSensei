using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpawn : MonoBehaviour
{
    public GameObject belt;
    Vector3 nextSpawnPoint;

    public void SpawnBelt()
    {
        GameObject temp = Instantiate(belt, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }

    private void Start()
    {
        for (int i = 0; i < 15; i++)
        {
            SpawnBelt();
        }
    }
}
