using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using BzKovSoft.ObjectSlicer.Samples;

public class Fruit : MonoBehaviour
{
   // public GameObject slicedFruits;

    Rigidbody2D rb;
    public float startForce = 15f;
    private Camera cam;

    public float speedLoss = 1;

    public bool canBeSliced=true;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
        cam = Camera.main;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Blade" && canBeSliced) { 

            FindObjectOfType<Combo>().AddTracker();

            ScoreManager.instance.AddPoint();

            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            var sliceId = SliceIdProvider.GetNewSliceId();

            var sliceableA = GetComponentInChildren<IBzSliceableNoRepeat>();

            Vector3 sliceDirection = Vector3.Cross(transform.position-cam.transform.position, direction);
            Plane plane = new Plane(sliceDirection, cam.transform.position);

            if (sliceableA != null)
                sliceableA.Slice(plane, sliceId, null);

            Rigidbody[] parts=GetComponentsInChildren<Rigidbody>();

            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].AddExplosionForce(200,transform.position,5);
                Vector3 rota = new Vector3(UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5), UnityEngine.Random.Range(-5, 5));
                parts[i].AddTorque(rota, ForceMode.Impulse);
            }




            //slicedFruits = Instantiate(slicedFruits, transform.position, rotation);

            FindObjectOfType<AudioManager>().Play("Slice"); // play sound

            /* Rigidbody[] slicedFruit = slicedFruits.GetComponentsInChildren<Rigidbody>();
             foreach (Rigidbody srb in slicedFruit)
             {
                 srb.velocity = rb.velocity;
             }

             Destroy(slicedFruits, 3f);
             Destroy(gameObject);*/
           canBeSliced = false;
        }
    }
}