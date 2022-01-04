using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawningBomb : MonoBehaviour
{
    [System.Serializable]
    public class SpawnChance
    {
        public string name;
        public GameObject item;
        public int spawnRarity;
    }

    public List<SpawnChance> RandomSpawn = new List<SpawnChance>();
    public int bombChance;

    void calculateSpawn()
    {
        int calc_bombChance = Random.Range(0, 100);

        if (calc_bombChance > bombChance)
        {
            print("something");
            return;
        }

        if (calc_bombChance<=bombChance)
        {
            int itemWeight = 0;
            for (int i = 0; i < RandomSpawn.Count; i++)
            {
                itemWeight += RandomSpawn[i].spawnRarity;
            }
            print("ItemWeight= " + itemWeight);
        }
    }

}