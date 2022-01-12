using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeTest : MonoBehaviour
{
    public GameObject trail;
    bool isCutting = false;
    Rigidbody2D rb;
    Camera cam;
    private GameObject currentTrail;
    private CircleCollider2D circleCollider;
    Vector2 previousPosition;
    public float minCuttingVelocity = .001f;

    private void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
        circleCollider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        trail.transform.position = new Vector3(newPos.x, newPos.y, -1);

        bool isActive = Input.GetKey(KeyCode.Mouse0);
        trail.SetActive(isActive);

        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        if (isCutting)
        {
            UpdateCut();
        }
    }

    void UpdateCut()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rb.position = newPosition;

        float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
        if (velocity>minCuttingVelocity)
        {
            circleCollider.enabled = true;
        }
        else
        {
            circleCollider.enabled = false;
        }

        previousPosition = newPosition;
    }

    void StartCutting()
    {
        isCutting = true;
        previousPosition = cam.ViewportToScreenPoint(Input.mousePosition);
        circleCollider.enabled = false;
    }

    void StopCutting()
    {
        isCutting = false;
        circleCollider.enabled = false;
    }
}
