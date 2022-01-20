using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpawn : MonoBehaviour
{
    public GameObject[] Prefab;

    Transform transformRemover;
    private float spawnX = 0.0f;
    private float tileLength = 10f;
    public int amnTilesOnScreen=7;

    private void Start()
    {
        transformRemover = GameObject.FindGameObjectWithTag("transformRemover").transform;
        for (int i = 0; i < amnTilesOnScreen; i++)
        {
            SpawnTile();
        }
    }

    private void Update()
    {
        if (transformRemover.position.x>spawnX-amnTilesOnScreen*tileLength)
        {
            SpawnTile();
        }
    }

    void SpawnTile(int prefabIndex=-1)
    {
        GameObject go;
        go = Instantiate(Prefab[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.left * spawnX;
       // go.transform.position = new Vector3(0, -1.89f, 1.88f);
        spawnX += tileLength;
    }
}
