using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody2D rbody2d; //Component rigidbody
    public float enemySpeed; //Variabel for enemy speed
    
    void Start()
    {
        rbody2d = gameObject.GetComponent<Rigidbody2D>(); //Gets rigidbody component
    }

    
    void Update()
    {
        
    }
}
