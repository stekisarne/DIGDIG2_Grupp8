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
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (movingRight == true && other.tag == "Walls" && circleCollider)
        {
            movingRight = false;
            movingDown = true;
            transform.Rotate(0.0f, 0.0f, -90.0f);
        }

        else if (movingDown == true && other.tag == "Walls" && circleCollider)
        {
            movingDown = false;
            movingLeft = true;
            transform.Rotate(0.0f, 0.0f, -rotationAngle);
        }

        else if (movingLeft == true && other.tag == "Walls" && circleCollider)
        {
            movingUp = true;
            movingLeft = false;
            transform.Rotate(0.0f, 0.0f, -rotationAngle);
        }

        else if (movingUp == true && other.tag == "Walls" && circleCollider)
        {
            movingRight = true;
            movingUp = false;
            transform.Rotate(0.0f, 0.0f, -rotationAngle);
        }
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
