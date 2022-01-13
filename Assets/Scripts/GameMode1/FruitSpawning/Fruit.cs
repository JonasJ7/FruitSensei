using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Fruit : MonoBehaviour
{
    


    public GameObject slicedFruits;

    Rigidbody2D rb;
    public float startForce = 15f;

    public float speedLoss = 1;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.tag == "Blade") {

            FindObjectOfType<Combo>().AddTracker();

            ScoreManager.instance.AddPoint();

            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            slicedFruits = Instantiate(slicedFruits, transform.position, rotation);

            FindObjectOfType<AudioManager>().Play("Slice"); // play sound

            Rigidbody[] slicedFruit = slicedFruits.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody srb in slicedFruit)
            {
                srb.velocity = rb.velocity;
            }

            Destroy(slicedFruits, 3f);
            Destroy(gameObject);
        }
    }
}