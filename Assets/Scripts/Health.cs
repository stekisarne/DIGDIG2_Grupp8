using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int baseHp = 10;
    public float scaling = 0.03f;
    public float extraLives = 0;
    public GameObject DeathSequence;
    int MaxHp;
    public float currentHp;
    private Rigidbody2D rb;

    private void Awake()
    {
        HPScaling();
        currentHp = MaxHp;
        GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (currentHp <= 0)
        {
            RespawnCheck();
        }
    }

    void HPScaling() //Sets the EnemyHp to the value of the enemyhp plus the time in seconds rounded to one number
    {
        MaxHp = Mathf.RoundToInt(baseHp + (Time.time) * scaling); // * dificulty scaling
    }
    public void OnHit(float damage, Vector2 knockbackAngle, float knockbackForce)
    {
        Debug.Log(gameObject.name + " hit for: " + damage + " damage");
        currentHp -= damage;
        rb.AddForce(knockbackAngle * knockbackForce, ForceMode2D.Impulse);
    }

    void RespawnCheck()
    {
        if (gameObject.tag == "Player"&& extraLives > 0)
        {
            respawnStart();
        }
        else { Death();}
   }

    private void respawnStart()
    {
        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerAttack>().enabled = false;
    }

    void Death()
    {
        Instantiate(DeathSequence);
        Destroy(this.gameObject);
    }
}
