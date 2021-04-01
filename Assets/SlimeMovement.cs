using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public Rigidbody2D rBody; //Component rigidbody
    public float enemySlimeSpeed; //Variabel for enemy speed
    public bool movingRight; //A bool to check if the enemy is moving tight or left
    public bool movingUp;
    public bool movingDown;

    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>(); //Gets rigidbody component
        movingRight = true;
    }

    void Update()
    {
        SlimeMoveDirection();
    }


    public void OnTriggerEnter2D(Collider2D Other) 
    {
        if (movingRight == true && Other.tag == "Walls")
        {
            movingRight = false;
            transform.Rotate(0.0f, 0.0f, 90.0f);
        }

        if (movingUp == true && Other.tag == "Ground")
        {
            movingRight = false;
            transform.Rotate(0.0f, 0.0f, 90.0f);
        }
    }

    public void OnTriggerExit2D(Collider2D Ohter)
    {
        
    }

    private void SlimeMoveDirection() //Sets the slimes movement direction
    {
        if(movingRight == true)
        {
            rBody.velocity = new Vector2(enemySlimeSpeed, 0.0f); //Sets enemy movement when movingRight
        }

        if(movingRight == false)
        {
            rBody.velocity = new Vector2(-enemySlimeSpeed, 0.0f); //Sets enemy movement when movingLeft
        }

        if(movingUp == true)
        {
            rBody.velocity = new Vector2(0.0f, enemySlimeSpeed); //Sets enemy movement when movingUp
        }

        if(movingDown == true)
        {
            rBody.velocity = new Vector2(0.0f, -enemySlimeSpeed); //Sets enemy movement when movingDown
        }
    }
}
