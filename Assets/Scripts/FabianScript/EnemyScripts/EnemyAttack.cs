using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int enemyDamage; //Sets the enemy damage 
    public EnemyMovement enemyMovement;
    public Animator enemyAnimator;
    public ParticleSystem biteParticle;
    public GameObject mouth; //Gameobject where a bite particle Instantiates
    public AudioSource attackAudio;
    public AudioSource walkAudio;
    PlayerHpScript playerHp;

    void Start()
    {
        playerHp = FindObjectOfType<PlayerHpScript>();
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

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            enemyAnimator.SetBool("NearPlayer", false);
            enemyMovement.enemySpeed = 1.5f;
        }
    }

    public void BiteParticle()
    {
        Instantiate(biteParticle, mouth.transform);
    }

    public void BiteAttack() //Deals damage to the player when an animationen event triggers this function
    {
        attackAudio.Play();
        playerHp.PlayerHit();
    }
}
