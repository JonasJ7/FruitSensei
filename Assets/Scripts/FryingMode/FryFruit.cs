using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryFruit : MonoBehaviour
{
    public GameObject slicedFruits;

    Rigidbody rb;
    public float startForce = 15f;

    public float speedLoss = 1;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * startForce, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider collision) {
        if (collision.tag == "Blade") {

            ScoreManager.instance.AddPoint();

            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            slicedFruits = Instantiate(slicedFruits, transform.position, rotation);

            Rigidbody[] slicedFruit = slicedFruits.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody srb in slicedFruit)
            {
                srb.velocity = rb.velocity;
            }

            Destroy(slicedFruits, 3f);
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);

    }
}