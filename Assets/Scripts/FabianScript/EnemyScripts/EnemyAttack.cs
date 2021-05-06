using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage; //Sets the enemy damage 
    EnemyMovement enemyMovement;
    Animator enemyAnimator;
    public ParticleSystem biteParticle;
    public GameObject mouth; //Gameobject where a bite particle Instantiates
    public AudioSource attackAudio;
    public AudioSource walkAudio;

    void Start()
    {
        enemyAnimator = FindObjectOfType<Animator>();
        enemyMovement = FindObjectOfType<EnemyMovement>();
        walkAudio.Play();
    }

    private void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) //Deals damage too the player character.
    {
        if (other.tag == "Player")
        {
            enemyAnimator.SetBool("NearPlayer", true);
            enemyMovement.enemySpeed = 0;
        }
        else if(other.tag != "Player")
        {
            enemyAnimator.SetBool("NearPlayer", false);
            enemyMovement.enemySpeed = 1.5f;
        }
    }

    public void BiteAttack() //Deals damage to the player when an animationen event triggers this function
    {
        Instantiate(biteParticle, mouth.transform);
        attackAudio.Play();
    }
}
