using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAttack : MonoBehaviour
{
    public int flyingEnemyDamage;
    public float cooldown;
    public float cooldownTimer;
    FlyingEnemyMovement flyingEnemyMovement;
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        flyingEnemyMovement = FindObjectOfType<FlyingEnemyMovement>();
    }

    
    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            Invoke("DamagePlayer", 1);
        }

    }

    private void DamagePlayer()
    {
        if (cooldownTimer <= 0)
        {
            playerHealth.playerHp -= flyingEnemyDamage;
            cooldownTimer = cooldown;
        }
    }
}
