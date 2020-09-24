using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rBody; //Component rigidbody
    public float enemySpeed; //Variabel for enemy speed
    public bool enemyGrounded; //A bool to check if the enemy is touching the ground
    public bool movingRight; //A bool to check if the enemy is moving tight or left

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
            rBody.velocity = new Vector2(-enemySpeed, 0.0f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (movingRight == true) //Changes if the enemy is moving right or left
        {
            movingRight = false;
        }
        else
        {
            movingRight = true;
        }

        transform.Rotate(0.0f, -180f, 0.0f);

    }
}
