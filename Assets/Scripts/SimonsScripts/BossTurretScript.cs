using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTurretScript : MonoBehaviour
{
    public Vector2 direction;
    public float distance;
    public LayerMask mask;
    public float turretDamage;
    // Start is called before the first frame update
    void Start()
    {
        SetDirection();
        mask = LayerMask.GetMask("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Fire", Random.Range(1f, 5f));
    }

    void Fire()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance, mask);

        if(hit.collider != null)
        {
          Health healthToDamage = hit.collider.GetComponent<Health>();
            healthToDamage.OnHit(turretDamage, Vector2.zero, 0f);
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
