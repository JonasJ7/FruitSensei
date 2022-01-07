using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSlice : MonoBehaviour
{
    [SerializeField] private Transform sliceTransform;
    public GameObject rb1;

    public void Start()
    {
        StartCoroutine(cool());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            sliceTransform.gameObject.SetActive(true);

        }
        //rb1.GetComponent<ConstantForce>().force = new Vector3(0, -1f, 0);
    }
    IEnumerator cool()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            rb1.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}