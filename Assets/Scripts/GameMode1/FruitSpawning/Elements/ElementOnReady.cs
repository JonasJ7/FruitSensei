using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementOnReady : MonoBehaviour
{

    public Spawner spawner;
    public FruitSpawner fruitSpawner;

    private KeyCode currentKey;
    private GameObject currentObj;

    private void Update() {
        if (Input.GetKeyDown(currentKey)) {
            fruitSpawner.Spawn(currentObj.GetComponent<ElementData>().fruit);
            spawner.RemoveObjects(currentObj);
            currentKey = KeyCode.Minus;
            ScoreManager.instance.AddPoint();
            FindObjectOfType<AudioManager>().Play("Throw"); // playing sound
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Element")) {
            currentKey = collision.GetComponent<ElementData>().key;
            currentObj = collision.gameObject;
        }
    }

    private void OnTriggerStay2D(Collider2D collision) {
        gameObject.GetComponent<Image>().color = Color.green;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        gameObject.GetComponent<Image>().color = Color.red;
    }


}