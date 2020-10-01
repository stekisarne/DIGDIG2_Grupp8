using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Camera cam;

    Vector2 playerPosition;
    Vector2 dashPoint;
    Rigidbody2D rBody;
    public float maxDistance;
    public float dashSpeed;
    void Start()
    {
        cam = Camera.main;
        rBody = GetComponent<Rigidbody2D>();
        playerPosition = gameObject.transform.position;
    }


    void Update()
    {
        DashToMouse();
    }
    void DashToMouse()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            Vector2 desiredDirection = dashPoint; // set this to the direction you want.
            Vector2 dashDirection = desiredDirection.normalized * rBody.velocity.magnitude;

            rBody.velocity = dashDirection;
        }
    }
    void GetDashPoint()
    {

        Vector3 mousePos = Input.mousePosition;

        Vector2 dashPoint = new Vector2();
        mousePos.z = 10;
        
        // compute where the mouse is in world space
        
        dashPoint = cam.ScreenToWorldPoint(mousePos);

        

    }

    
    private void FixedUpdate()
    {
        
    }
}



    
