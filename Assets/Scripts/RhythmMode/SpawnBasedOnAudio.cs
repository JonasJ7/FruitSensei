using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBasedOnAudio : MonoBehaviour
{
    public GameObject objectToSpawn;
    public AudioSource audioSource;
    public float spawnThreshold = 0.5f;
    public int frequency = 0;
    public FFTWindow fftWindow;
    public float startSong=10;
    //public float debugValue;

    private float[] samples = new float[1024];

    private void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.PlayDelayed(startSong);
     
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.GetSpectrumData(samples, 0, fftWindow);

       // debugValue = samples[frequency];

        if (samples[frequency]>spawnThreshold)
        {
            Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
    }
}

