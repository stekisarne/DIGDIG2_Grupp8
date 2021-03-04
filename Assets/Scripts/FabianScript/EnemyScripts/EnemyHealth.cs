using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int baseHp = 10;

    int enemyMaxHp;
    public float enemyHp;
    public float Timer;
    private Rigidbody2D rb;

    private void Awake()
    {
        EnemyHPScaling();
        enemyHp = enemyMaxHp;
        GetComponent<Rigidbody2D>();
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
    public void OnHit(float damage, Vector2 knockbackAngle, float knockbackForce)
    {
        Debug.Log("enemy hit for: " + damage + " damage");
        enemyHp -= damage;
        rb.AddForce(knockbackAngle * knockbackForce, ForceMode2D.Impulse);
    }

    void enemyDeath()
    {
        if (enemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
