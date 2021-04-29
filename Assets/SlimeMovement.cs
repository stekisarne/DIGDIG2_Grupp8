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

    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>(); //Gets rigidbody component
        movingRight = true;
    }

    void Update()
    {
        SlimeMoveDirection();
        rotationAngle = 90.0f;
    }


    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (movingRight == true && (Other.tag == "Walls" || Other.tag == "Ground"))
        {
            movingRight = false;
            movingUp = true;
            transform.Rotate(0.0f, 0.0f, rotationAngle);
        }

        else if (movingUp == true && (Other.tag == "Ground" || Other.tag == "Walls"))
        {
            movingUp = false;
            movingLeft = true;
            transform.Rotate(0.0f, 0.0f, rotationAngle);
        }

        else if (movingLeft == true && Other.tag == "Ground")
        {
            movingLeft = false;
            movingDown = true;
            transform.Rotate(0.0f, 0.0f, rotationAngle);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (movingRight == true && other.tag == "Ground" )
        {
            movingRight = false;
            movingDown = true;
            transform.Rotate(0.0f, 0.0f, -90.0f);
            Debug.Log("MovingDown");
        }

        else if (movingDown == true && other.tag == "Ground" )
        {
            movingDown = false;
            movingLeft = true;
            transform.Rotate(0.0f, 0.0f, -rotationAngle);
            Debug.Log("MovingLeft");
        }

        else if (movingLeft == true && other.tag == "Ground")
        {
            movingUp = true;
            movingLeft = false;
            transform.Rotate(0.0f, 0.0f, -rotationAngle);
            Debug.Log("MovingUp");
        }

        else if (movingUp == true && (other.tag == "Ground" || other.tag == "Walls"))
        {
            movingRight = true;
            movingUp = false;
            transform.Rotate(0.0f, 0.0f, -rotationAngle);
            Debug.Log("MovingRight");
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
