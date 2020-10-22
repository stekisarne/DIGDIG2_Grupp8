using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyHp;
    public int enemyMaxHp;
    public bool takenDamage;
    public float Timer;

    private void Awake()
    {
        enemyHp = 10;
    }

    void Update()
    {
        Timer = Time.time;
        enemyMaxHp = enemyHp;
        EnemyHPScaling();
        EnemyDamaged();
        enemyDeath();
    }

    void EnemyHPScaling() //Sets the EnemyHp to the value of the enemyhp plus the time in seconds rounded to one number
    {
        enemyHp = enemyHp + (Mathf.RoundToInt(Timer));
    }

    void EnemyDamaged()
    {
        if(enemyHp < enemyMaxHp)
        {
            takenDamage = true;
        }

        if (takenDamage == true)
        {
            
        }
    }

    void enemyDeath()
    {
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
