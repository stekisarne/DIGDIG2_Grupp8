using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemyAttack : MonoBehaviour
{
    public int flyingEnemyDamage;
    FlyingEnemyMovement flyingEnemyMovement;
    PlayerHealth playerHealth;
    void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        flyingEnemyMovement = FindObjectOfType<FlyingEnemyMovement>();
    }

    
    void Update()
    {
        
    }
}
