using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FryBomb : MonoBehaviour
{
    public GameObject slicedBomb;

    Rigidbody rb;
    public float startForce = 15f;

    public float speedLoss = 1;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.up * startForce, ForceMode.Impulse);
    }

    /*private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Blade")
        {

            ScoreManager.instance.AddPoint();

            Vector3 direction = (collision.transform.position - transform.position).normalized;

            Quaternion rotation = Quaternion.LookRotation(direction);

            slicedBomb = Instantiate(slicedBomb, transform.position, rotation);

            Rigidbody[] slicedBomb = slicedBomb.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody srb in slicedBomb)
            {
                srb.velocity = rb.velocity;
            }

            Destroy(slicedBomb, 3f);
            Destroy(gameObject);
        }
    }*/

    private void Update()
    {
        transform.Rotate(0, 0, 360 * Time.deltaTime);

    }
}