using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage; //Sets the enemy damage 
    PlayerHealth playerHealth;  //A connection with the player health script
    Animator enemyAnimator;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();    //Finds the object with the PlayerHealth script. 
        enemyAnimator = FindObjectOfType<Animator>();
    }

    public void OnTriggerEnter2D(Collider2D other) //Deals damage too the player character.
    {
        if (other.tag == "Player")
        {
            enemyAnimator.SetBool("NearPlayer", true);
            playerHealth.playerHp -= enemyDamage;
            playerHealth.Death();
        }
        else
        {
            enemyAnimator.SetBool("NearPlayer", false);
        }
    }
}
