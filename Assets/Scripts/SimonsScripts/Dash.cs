using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Camera cam;

    Vector3 playerPosition;
    
    Rigidbody2D rBody;
    public float maxDistance;
    public float dashSpeed;
    Vector3 dashDirection;
    Vector3 screenPos;
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
            var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPos.z = transform.position.z;
            transform.position = Vector3.MoveTowards(transform.position, targetPos, dashSpeed * Time.deltaTime);

        }
    }
    void GetDashPoint()
    {

        

        

    }

    
    
}



    
