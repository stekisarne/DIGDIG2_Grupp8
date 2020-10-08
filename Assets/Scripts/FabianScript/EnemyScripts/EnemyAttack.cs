using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage; //Sets the enemy damage 
    PlayerHealth playerHealth;  //A connection with the player health script

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    public void OnTriggerEnter2D(Collider2D other) //Deals damage too the player character.
    {
        if(other.tag == "Player")
        {
            playerHealth.playerHp -= enemyDamage;
            playerHealth.Death();
        }
    }
}
