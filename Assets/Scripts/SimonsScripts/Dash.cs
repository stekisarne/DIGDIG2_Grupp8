using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rBody;
    PlayerMovement playerMovement;
    public CircleCollider2D hurtbox; 

    public float dashCD = 3;
    private float currentDashCD;
    public float dashDuration;
    private float currentDashDuration;
    private bool isDashing;
    public float dashSpeed;
    Vector2 dir;

    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (currentDashCD <= 0)
        {
            PlayerDash();
        }
        else
        {
            playerMovement.enabled = true;
            hurtbox.enabled = true;
            currentDashCD = Mathf.Max(0, currentDashCD - Time.deltaTime);
        }
    }

    private void PlayerDash()
    {
        if (currentDashDuration > 0)
        {
            isDashing = true;
            Dashing();
        }
        else if (isDashing == true)
        {
            StopDash();
            isDashing = false;
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            StartDash();
        }
    }

    void StartDash()
    {              
        currentDashDuration = dashDuration;
        dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
    
    void Dashing()
    {
        playerMovement.enabled = false;
        hurtbox.enabled = false;
        currentDashDuration = Mathf.Max(0, currentDashDuration - Time.deltaTime);
        rBody.velocity = dir.normalized * dashSpeed;    
    }
    void StopDash()
    {
        currentDashCD = dashCD;
        rBody.velocity = new Vector2(0, 0);
    }
}



    
