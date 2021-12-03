using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceSpawner : MonoBehaviour
{

    public GameObject fruit;
    public Transform[] spawnPoints;
    public float minDelay = .1f;
    public float maxDelay = 1f;

    public float force;

    int spawnIndex;
    Transform spawnPoint;
    // [SerializeField] float rotateSpeed = 60f;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnFruits());
    }

    IEnumerator SpawnFruits()
    {
        while (true)
        {
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(1f);

            // Spawn fruit

            spawnIndex = Random.Range(0, spawnPoints.Length);
            spawnPoint = spawnPoints[spawnIndex];

            GameObject spawnedFruit = Instantiate(fruit, spawnPoint.position, spawnPoint.rotation);
            spawnedFruit.GetComponent<Rigidbody>().AddForce(0, 0, 1000f);
            Destroy(spawnedFruit, 5f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //spawnPoint.transform.localEulerAngles = new Vector3(0, 0, Mathf.PingPong(Time.time * rotateSpeed, 80) - 45);
    }
}
