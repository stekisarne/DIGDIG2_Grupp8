using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float enemyDamage; //Sets the enemy damage 

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //Player health - enemyDamage.
            //Player takes X amount of damage.
            //Needs conection with a player health script
        }
    }
}
