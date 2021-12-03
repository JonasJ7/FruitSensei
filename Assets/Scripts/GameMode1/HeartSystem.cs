using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartSystem : MonoBehaviour
{
    [SerializeField] GameObject heartPrefab;
    [SerializeField] GameObject brokenPrefab;

    public void DrawHearts (int hearts, int maxHearts)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < maxHearts; i++)
        {
            if (i+1<=hearts)
            {
                GameObject heart = Instantiate(heartPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
            else
            {
                GameObject heart = Instantiate(brokenPrefab, transform.position, Quaternion.identity);
                heart.transform.parent = transform;
            }
        }
    }
}
