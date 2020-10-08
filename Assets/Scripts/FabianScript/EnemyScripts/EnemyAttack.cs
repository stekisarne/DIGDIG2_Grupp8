using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage; //Sets the enemy damage 
    PlayerHealth playerHealth;  //A connection with the player health script

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Have a collison enter that deals damage to a gameobject with a specific tag.
    }
}
