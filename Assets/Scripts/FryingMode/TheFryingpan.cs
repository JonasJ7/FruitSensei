using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheFryingpan : MonoBehaviour
{
    public Rigidbody rb;
    private Vector3 p�re;
    private Vector3 niels;
    void Start()
    {

        Vector3 newPosition = transform.position; 

        transform.position = newPosition;

        rb.GetComponent<Rigidbody>();

        p�re = new Vector3(0, 6, 0);

        niels = transform.position;
    }
    private void Update()
    {
        if (Input.GetKey("f"))
        {
            //transform.position += new Vector3(0, 1, 0);
            rb.MovePosition(Vector3.MoveTowards(transform.position, p�re, 0.1f));
            
        }
        else
        {
            rb.MovePosition(Vector3.MoveTowards(transform.position, niels, 0.05f));
        }
    }
}

