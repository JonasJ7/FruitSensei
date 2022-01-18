using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBelt : MonoBehaviour
{
    BeltSpawn beltSpawn;

    private void Start()
    {
        beltSpawn = GameObject.FindObjectOfType<BeltSpawn>();
    }

    private void OnTriggerExit(Collider other)
    {
        beltSpawn.SpawnBelt();
        Destroy(gameObject, 2);
    }
}
