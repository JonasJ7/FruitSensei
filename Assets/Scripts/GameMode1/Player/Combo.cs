using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    //private List<Vector3> myHitList = new List<Vector3>();
    //public Collider2D[] hits;
    public GameObject combo3;
    public GameObject combo6;
    public GameObject combo8;
    public GameObject combo10;
    private float hit;

    public int multiTracker;
    [SerializeField] private Camera mainCamera;

    public float timer;
    public float cutTime;
    public bool isTiming;

    private void Start()
    {
        timer = cutTime;
    }
    private void Update()
    {
        if (isTiming == true)
        {
            timer -= Time.deltaTime;
        }

        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;
        transform.position = mouseWorldPosition;
    }

    public void AddTracker()
    {
        multiTracker++;

        if (multiTracker == 3)
        {
            Debug.Log(isTiming + "Timing");
            isTiming = true;
            if (timer > 0)
            {
                FindObjectOfType<AudioManager>().Play("Great");
                Instantiate(combo3, transform.position, Quaternion.identity);
            }
        }

        if (multiTracker == 6)
        {
            Debug.Log(isTiming + "Timing");
            isTiming = true;
            if (timer > 0)
            {
                FindObjectOfType<AudioManager>().Play("Juicy");
                Instantiate(combo6, transform.position, Quaternion.identity);
            }
        }

        if (multiTracker == 8)
        {
            Debug.Log(isTiming + "Timing");
            isTiming = true;
            if (timer > 0)
            {
                FindObjectOfType<AudioManager>().Play("Succulent");
                Instantiate(combo8, transform.position, Quaternion.identity);
            }
        }

        if (multiTracker == 10)
        {
            Debug.Log(isTiming + "Timing");
            isTiming = true;
            if (timer > 0)
            {
                FindObjectOfType<AudioManager>().Play("Succulent");
                Instantiate(combo10, transform.position, Quaternion.identity);
            }
        }

        if (timer <= 0)
        {
            multiTracker = 0;
        }

        /* if (timer>0)
         {
              if (multiTracker == 3)
               {
                   Debug.Log("Count" + multiTracker);
                   Instantiate(combo3, transform.position, Quaternion.identity);
               }
               if (multiTracker == 6)
               {
                   Debug.Log("Count" + multiTracker);
                   Instantiate(combo6, transform.position, Quaternion.identity);
               }
               if (multiTracker == 8)
               {
                   Debug.Log("Count" + multiTracker);
                   Instantiate(combo8, transform.position, Quaternion.identity);
               }
               if (multiTracker == 10)
               {
                   Debug.Log("Count" + multiTracker);
                   Instantiate(combo10, transform.position, Quaternion.identity);
               }
           }
           else
           {
               if (timer<=0)
               {
                   ResetTracker();
               }
           }
         }
         



        public void ResetTracker()
        {
            multiTracker = 0;
        }*/
    }
}
