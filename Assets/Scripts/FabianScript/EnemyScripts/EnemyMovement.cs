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

    private void OnTriggerExit2D(Collider2D other)  //Changes if the enemy is moving right or left
    {
        if (movingRight == true) 
        {
            movingRight = false;
            transform.Rotate(0.0f, -180f, 0.0f);
        }
        else
        {
            movingRight = true;
            transform.Rotate(0.0f, 180f, 0.0f);
        }
    }
}
