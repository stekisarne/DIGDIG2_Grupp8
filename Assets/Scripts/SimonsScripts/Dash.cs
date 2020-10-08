using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    

    
    
    Rigidbody2D rBody;

    public float maxDistance;
    public float dashSpeed;
    public float angle;

    Vector3 playerPosition;
    Vector3 dashDirection;
    Vector3 screenPos;
    void Start()
    {
        
        rBody = GetComponent<Rigidbody2D>();
        playerPosition = gameObject.transform.position;
    }


    void Update()
    {
        DashInDirection();
    }
    void DashInDirection()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            angle = Mathf.Atan2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal")) * Mathf.Rad2Deg;

            dashDirection = new Vector2(angle, angle);

            rBody.velocity = dashDirection * dashSpeed;
        }
    }
    

    
    
}



    
