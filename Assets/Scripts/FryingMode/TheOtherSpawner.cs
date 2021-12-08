using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheOtherSpawner : MonoBehaviour
{

    public List<GameObject> objectsToSpawn = new List<GameObject>();
    public List<GameObject> objs;
    public float timeToSpawn, speed;
    public float timeToSpawnFaster = 30, timeholder;
    private float currentTimeToSpawn;
    public GameObject SpawnPoint;

    void Start() {
        objs = new List<GameObject>();
        currentTimeToSpawn = timeToSpawn;
        SpawnObjects();
        timeholder = timeToSpawnFaster;
    }
    public void SpawnObjects() {
        int index = Random.Range(0, objectsToSpawn.Count);
        if (objectsToSpawn.Count > 0) {
            GameObject obj = Instantiate(objectsToSpawn[index], new Vector3(SpawnPoint.transform.position.x, SpawnPoint.transform.position.y, SpawnPoint.transform.position.z), transform.rotation);
            objs.Add(obj);
        }
    }
    private void Update() {
        
        if (objs.Count > 0)
        {

            for (int i = objs.Count; i > 0; i--)
            {
                if (objs[i-1] != null)
                {
                    objs[i-1].transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
                    if (objs[i-1].transform.localPosition.x < -1100)
                    {
                        objs.RemoveAt(i-1);
                        Destroy(objs[i-1]);
                    }
                }
            }
        }
        /*
        foreach (GameObject obj in objs) {
            obj.transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;

            if (obj.transform.localPosition.x < -1100) {
                objs.Remove(obj);
                Destroy(obj);
            }
        }
                */
        UpdateTimer();

        if (timeholder > 0) {
            timeholder -= 1 * Time.deltaTime;
        } else {
            if (timeToSpawn < 1f) {
                return;
            }
            timeholder = timeToSpawnFaster;
            timeToSpawn /= 2;
        }

    }
    void UpdateTimer() {
        if (currentTimeToSpawn > 0) {
            currentTimeToSpawn -= Time.deltaTime;
        } else {
            SpawnObjects();
            currentTimeToSpawn = timeToSpawn;
        }
    }
    public void RemoveObjects(GameObject objDelete) {
        objs.Remove(objDelete);
        Destroy(objDelete);
    }
}