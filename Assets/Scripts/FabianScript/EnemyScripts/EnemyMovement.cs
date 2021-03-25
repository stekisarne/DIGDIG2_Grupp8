using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rBody; //Component rigidbody
    public float enemySpeed; //Variabel for enemy speed
    public bool enemyGrounded; //A bool to check if the enemy is touching the ground
    public bool movingRight; //A bool to check if the enemy is moving tight or left
    public GameObject WallDetector; //GameObject in place to see if its collider triggers with a wall collider

    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>(); //Gets rigidbody component
        movingRight = true;
    }


    void Update()
    {
        rBody.velocity = new Vector2(enemySpeed, 0.0f); //Sets enemy movement

        if (movingRight == false)
        {
            rBody.velocity = new Vector2(-enemySpeed, 0.0f);    //Inverts the enemies speed.
        }
    }

    private void OnTriggerEnter2D(Collider2D other)  //Changes if the enemy is moving right or left when Entering a wall
    {
        if (movingRight == true && other.tag == "Walls") 
        {
            movingRight = false;
            transform.Rotate(0.0f, -180f, 0.0f);
            Debug.Log("TriggerWall 1");
        }
        else if (movingRight == false && other.tag == "Walls")
        {
            movingRight = true;
            transform.Rotate(0.0f, 180f, 0.0f);
            Debug.Log("TriggerWall 2");
        }
    }

    private void OnTriggerExit2D(Collider2D other) //Changes if the enemy is moving right or left when exiting ground.
    {
        if (movingRight == true && other.tag == "Ground")
        {
            movingRight = false;
            transform.Rotate(0.0f, -180f, 0.0f);
            Debug.Log("TriggerGround 1");
        }
        else if (movingRight == false && other.tag == "Ground")
        {
            movingRight = true;
            transform.Rotate(0.0f, 180f, 0.0f);
            Debug.Log("Triggerground 2");
        }
    }
}
