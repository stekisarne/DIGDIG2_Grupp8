using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage; //Sets the enemy damage 
    PlayerHealth playerHealth;  //A connection with the player health script
    EnemyMovement enemyMovement;
    Animator enemyAnimator;
    public ParticleSystem biteParticle;
    public GameObject mouth; //Gameobject where a bite particle Instantiates
    public AudioSource walkAudio;
    public AudioSource attackAudio;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();    //Finds the object with the PlayerHealth script. 
        enemyAnimator = FindObjectOfType<Animator>();
        enemyMovement = FindObjectOfType<EnemyMovement>();
        walkAudio.Play();
    }

    private void Update()
    {
        if (playerHealth != null)
        {
            enemyAnimator.SetBool("PlayerIsDead", true);
            playerHealth.Death();
        }
    }

    public void OnTriggerEnter2D(Collider2D other) //Deals damage too the player character.
    {
        if (other.tag == "Player")
        {
            enemyAnimator.SetBool("NearPlayer", true);
            enemyMovement.enemySpeed = 0;
            walkAudio.Stop();
        }
        else if(other.tag != "Player")
        {
            enemyAnimator.SetBool("NearPlayer", false);
            enemyMovement.enemySpeed = 1.5f;
            walkAudio.Play();
        }
    }

    public void BiteAttack() //Deals damage to the player when an animationen event triggers this function
    {
        playerHealth.playerHp -= enemyDamage;
        Instantiate(biteParticle, mouth.transform);
        attackAudio.Play();
    }
}
