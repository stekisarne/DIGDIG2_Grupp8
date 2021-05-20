using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rBody;
    PlayerMovement playerMovement;
    public CircleCollider2D hurtbox;
    private PlayerAnimationHandler anim;

    public bool canDash;
    public float dashDuration;
    private float currentDashDuration;
    private bool isDashing;
    private PlayerMovement movementScript;
    public float dashSpeed;

    Vector2 dir;

    void Start()
    {

        movementScript = GetComponent<PlayerMovement>();
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<PlayerAnimationHandler>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (canDash)
        {
            PlayerDash();
        }
        else
        {
            playerMovement.enabled = true;
            hurtbox.enabled = true;
            anim.dashing = false;           
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
        if (Input.GetAxis("Vertical") != 0)
        {
            dir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else if (movementScript.isFacingRight)
        {
            dir = Vector2.right;

        }
        else
        {
            dir = Vector2.left;
        }
    }
    
    void Dashing()
    {
        playerMovement.enabled = false;
        hurtbox.enabled = false;
        anim.dashing = true;
        currentDashDuration = Mathf.Max(0, currentDashDuration - Time.deltaTime);
        rBody.velocity = dir.normalized * dashSpeed;    
    }
    void StopDash()
    {
        movementScript.remainingJumps = movementScript.airJumps;
        canDash = false;
        rBody.velocity = new Vector2(0, 0);
    }
}



    
