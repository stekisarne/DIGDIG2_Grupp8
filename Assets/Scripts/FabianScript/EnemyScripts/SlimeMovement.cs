using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public Rigidbody2D rBody; //Component rigidbody
    public float enemySlimeSpeed; //Variabel for enemy speed
    public bool movingRight; //A bool to check if the enemy is moving right
    public bool movingLeft; //A bool to check if the enemy is moving left
    public bool movingUp; //A bool to check if the enemy is moving up
    public bool movingDown; //A bool to check if the enemy is moving down
    public float rotationAngle; //Sets the rotation angle 
    public CircleCollider2D circleCollider;
    public GameObject slimeFeet1;
    public GameObject slimeFeet2;
    public GameObject slimeFeet3;

    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>(); //Gets rigidbody component
        circleCollider = gameObject.GetComponent<CircleCollider2D>();
        movingRight = true;
    }

    void Update()
    {
        SlimeMoveDirection();
        rotationAngle = 90.0f;

        RaycastHit2D SlimeFeet1 = Physics2D.Raycast(slimeFeet1.transform.position, -transform.up);
        RaycastHit2D SlimeFeet2 = Physics2D.Raycast(slimeFeet2.transform.position, -transform.up);
        RaycastHit2D SlimeFeet3 = Physics2D.Raycast(slimeFeet3.transform.position, -transform.up);
        Debug.DrawRay(slimeFeet1.transform.position, -transform.up, Color.green);
        Debug.DrawRay(slimeFeet2.transform.position, -transform.up, Color.green);
        Debug.DrawRay(slimeFeet3.transform.position, -transform.up, Color.green);
    }

    private void SlimeMoveDirection() //Sets the slimes movement direction
    {
        if (movingRight == true)
        {
            rBody.velocity = new Vector2(enemySlimeSpeed, 0.0f); //Sets enemy movement when movingRight
        }

        if (movingLeft == true)
        {
            rBody.velocity = new Vector2(-enemySlimeSpeed, 0.0f); //Sets enemy movement when movingLeft
        }

        if (movingUp == true)
        {
            rBody.velocity = new Vector2(0.0f, enemySlimeSpeed); //Sets enemy movement when movingUp
        }

        if (movingDown == true)
        {
            rBody.velocity = new Vector2(0.0f, -enemySlimeSpeed); //Sets enemy movement when movingDown
        }
    }
}
