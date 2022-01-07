using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VFX
{
    public new string name;
    public ParticleSystem ParticleEffect;

    [HideInInspector]
    public ParticleSystem pSystem;
}
