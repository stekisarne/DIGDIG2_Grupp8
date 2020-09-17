using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rBody; //Component rigidbody
    public float enemySpeed; //Variabel for enemy speed
    public bool enemyGrounded;
    
    void Start()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>(); //Gets rigidbody component
    }

    
    void Update()
    {
        rBody.velocity = new Vector2(enemySpeed, 0.0f);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.Rotate(0.0f, -180f, 0.0f);
        
    }
}
