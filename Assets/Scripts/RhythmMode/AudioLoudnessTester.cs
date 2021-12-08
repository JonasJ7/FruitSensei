using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLoudnessTester : MonoBehaviour
{
    public AudioSource audioSource;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;
    public float clipLoadness;
    private float[] clipSampleData;

    public GameObject sprite;
    public float sizeFactor = 1;

    public float minSize=0;
    public float maxSize=500;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update()
    {
        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime>=updateStep)
        {
            currentUpdateTime = 0;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples);
            clipLoadness = 0f;
           foreach (var sample in clipSampleData)
            {
                clipLoadness += Mathf.Abs(sample);
            }
            clipLoadness /= sampleDataLength;

            clipLoadness *= sizeFactor;
            clipLoadness = Mathf.Clamp(clipLoadness, minSize, maxSize);
            sprite.transform.localScale = new Vector3(clipLoadness, clipLoadness, clipLoadness);
        }
    }

}
