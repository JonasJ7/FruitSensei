using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeltSpeed : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}