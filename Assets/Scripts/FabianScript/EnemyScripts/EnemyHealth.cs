using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHp = 10;

    int enemyMaxHp;
    int enemyHp;
    public bool takenDamage;
    public float Timer;

    private void Awake()
    {
        EnemyHPScaling();
        enemyHp = enemyMaxHp;
    }

    void Update()
    {
        Timer = Time.time;
        enemyDeath();
    }

    void EnemyHPScaling() //Sets the EnemyHp to the value of the enemyhp plus the time in seconds rounded to one number
    {
        enemyMaxHp = Mathf.RoundToInt(baseHp + (Timer) * 0.03f) ; // * dificulty scaling
    }

    void enemyDeath()
    {
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
