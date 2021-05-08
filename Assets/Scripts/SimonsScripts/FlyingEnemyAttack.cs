using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAttack : MonoBehaviour
{
    public int flyingEnemyDamage;


    public float explosionRange;

    FlyingEnemyMovement flyingEnemyMovement;
    PlayerHpScript playerHealth;
    Health flyingEnemyHealth;

    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHpScript>();
        flyingEnemyMovement = GetComponent<FlyingEnemyMovement>();
        flyingEnemyHealth = GetComponent<Health>();
    }


    void Update()
    {
        Explosion();
    }

    void Explosion()
    {
        if (explosionRange > flyingEnemyMovement.distanceFromPlayer)
        {
            flyingEnemyMovement.currentState = FlyingEnemyMovement.State.Exploding;

            Invoke("Explode", 1);
        }
    }

    void Explode()
    {

        if (explosionRange > flyingEnemyMovement.distanceFromPlayer)
        {
            playerHealth.PlayerHit();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }


    }

}
