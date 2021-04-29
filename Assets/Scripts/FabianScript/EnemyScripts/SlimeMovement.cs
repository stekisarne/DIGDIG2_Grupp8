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
    public GameObject slimeFeet1;
    public bool slimeIsOnGround;

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
