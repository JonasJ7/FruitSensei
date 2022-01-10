using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class VFXManager : MonoBehaviour
{
    public VFX[] effects;
    private int index;
    public Vector3 spawnPos;
    public static VFXManager instance;

    private void Awake()
    {
        foreach (VFX effect in effects)
        {
            effect.pSystem = gameObject.AddComponent<ParticleSystem>();
        }
    }

    public void PlayVFX(string name, int destroyTime)
    {
        Debug.Log(name);
        VFX effect = Array.Find(effects, vfx => vfx.name == name);
        if (effect==null)
        {
            Debug.LogWarning("VFX: " + name + " not found!");
            return;
        }
        effect.pSystem.Play();
    }

    public void InstantiateObject()
    {
        //Instantiate(effects[index], transform.position, transform.rotation, Quaternion.identity);
    }

}
