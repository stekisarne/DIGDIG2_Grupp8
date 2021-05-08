using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurretScript : MonoBehaviour
{
    public Vector2 direction;
    public float distance;
    public LayerMask mask;
    public float randomCooldown;
    public float nextAttack;
    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
        mask = LayerMask.GetMask("Player");
        randomCooldown = Random.Range(2f, 5f);
        nextAttack = Time.time + randomCooldown;
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if(nextAttack - Time.time <= 1f && nextAttack - Time.time > 0f)
        {

        }

        if(Time.time >= nextAttack)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, mask);

            if (hit.collider != null)
            {
                PlayerHpScript healthToDamage = hit.collider.GetComponent<PlayerHpScript>();
                healthToDamage.PlayerHit();
                randomCooldown = Random.Range(2f, 5f);
                nextAttack = Time.time + randomCooldown;
            }
            else
            {
                randomCooldown = Random.Range(2f, 5f);
                nextAttack = Time.time + randomCooldown;
            }
        }
        
    }

    void SetDirection()
    {
        if(this.gameObject.tag == "Turret")
        {
            direction = -Vector2.up;
        }
        else if(this.gameObject.tag == "Turret2")
        {
            direction = Vector2.right;
        }
        else if(this.gameObject.tag == "Turret3")
        {
            direction = Vector2.left;
        }
    }
}
