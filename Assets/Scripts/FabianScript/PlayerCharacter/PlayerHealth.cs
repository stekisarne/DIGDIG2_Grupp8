using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHp;    //A variabel for the player health points.
    EnemyMovement enemyMovement; //Adds connection to the Enemymovement
    Animator enemyAnimator; //Adds a connection to the enemy animator

    public void Awake() //Sets the players health to a set value before the game starts
    {
        playerHp = 100;
    }

    void Start()
    {
        enemyAnimator = FindObjectOfType<Animator>();
        enemyMovement = FindObjectOfType<EnemyMovement>();
    }

    public void Death()
    {
        if(playerHp <= 0)   //I the player characters health goes under or is equal too 0 it destroyes the game object.
        {
            enemyAnimator.SetBool("NearPlayer", false);
            enemyAnimator.SetBool("PlayerIsDead", true);
            enemyMovement.enemySpeed = 1.5f;
            Destroy(this.gameObject);
        }
    }
}
