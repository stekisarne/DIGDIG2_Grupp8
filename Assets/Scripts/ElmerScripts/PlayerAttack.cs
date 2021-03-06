﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement movementScript;
    PlayerAnimationHandler anim;
    Animator swordAnim;
    private Rigidbody2D playerRB;
    private BoxCollider2D basicHB;
    CircleCollider2D SlamHB;
    float angle;
    float knockbackAngleX;
    float knockbackAngleY;
    private Health target;
    private Vector2 knockbackAngle;
    private Dash dash;

    [Header("slaming")]
    [SerializeField] public float slamVelocity;
    public float bounceUp;

    [Header("basic attack")]
    [SerializeField] public float damage;
    public float basicCD;
    float currentBasicCD;
    public float knockbackForce = 3;
    public float selfKnockbackForce = 3;
    public float lungeDamper = 150;


    // Start is called before the first frame update
    void Start()
    {

        dash = GetComponentInParent<Dash>();
        SlamHB = GetComponent<CircleCollider2D>();
        swordAnim = GetComponent<Animator>();
        anim = GetComponentInParent<PlayerAnimationHandler>();
        playerRB = GetComponentInParent<Rigidbody2D>();
        movementScript = GetComponentInParent<PlayerMovement>();
        basicHB = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (anim.slaming == false && currentBasicCD <= 0)
        {
            StartBasicAttack();
        }
        currentBasicCD = Mathf.Max(currentBasicCD - Time.deltaTime, 0);
        
        if (anim.slaming)
        {
            Slaming();
        }else if(anim.startSlaming)
        {
            playerRB.velocity = new Vector2(0, 0);
        }
        else if (Input.GetButtonDown("Fire2") && !movementScript.isGrounded)
        {          
            anim.startSlaming = true;
            Debug.Log("Start Slam");
        }
    }
    public void StartSlam()
    {
        SlamHB.enabled = true;
        anim.startSlaming = false;
        anim.slaming = true;
        playerRB.velocity = new Vector2(0, -slamVelocity);
    }

    private void Slaming()
    {
        movementScript.enabled = false;       
        if (playerRB.velocity.y >= 0)
        {
            anim.slaming = false;
            Debug.Log("Stop Slam");
            movementScript.enabled = true;
            movementScript.remainingJumps = movementScript.airJumps;
            dash.canDash = true;
            SlamHB.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            target = collision.GetComponent<Health>();
            if (target != null)
            {
                playerRB.velocity = Vector2.zero;
                if (anim.slaming)
                {
                    playerRB.velocity = new Vector2(0, bounceUp);
                }
                else
                {
                    playerRB.AddForce(-knockbackAngle * selfKnockbackForce, ForceMode2D.Impulse);
                }
                target.OnHit(damage, knockbackAngle, knockbackForce);
            }
        }
    }

    private void StartBasicAttack()
    {
        
        if (Input.GetButtonDown("Fire1"))
        {
            SwordRotation();
            playerRB.velocity =  new Vector2(0, playerRB.velocity.y);
            playerRB.AddForce(knockbackAngle * movementScript.moveSpeed / lungeDamper,ForceMode2D.Impulse);
            movementScript.canTurn = false;
            Debug.Log(movementScript.canTurn);
            currentBasicCD = Mathf.Infinity;
            swordAnim.Play("sword swing");
        }       
    }
    public void AttackStart()
    {
        Debug.Log("attack start");
        basicHB.enabled = true;
        anim.attacking = true;      
    }
    public void AttackEnd()
    {
        Debug.Log("attack stop");
        basicHB.enabled = false;
        anim.attacking = false;
       currentBasicCD = basicCD;
    }

    private void SwordRotation()
    {        
        if (Input.GetAxis("Vertical") != 0)
        {
            knockbackAngleX = Input.GetAxis("Horizontal");
            knockbackAngleY = Input.GetAxis("Vertical");
            knockbackAngle = new Vector2(knockbackAngleX, knockbackAngleY).normalized;
            angle = Mathf.Atan2(knockbackAngleX, knockbackAngleY) * Mathf.Rad2Deg * -1 + 90;
        }
        else if (movementScript.isFacingRight)
        {
            angle = 0;
            knockbackAngle = Vector2.right;
            
        }
        else { 
            angle = 180;
            knockbackAngle = Vector2.left;
        }
        if (angle < -90 || angle > 90)
        {
            transform.rotation = Quaternion.Euler(new Vector3(180, 0, -angle));
        } else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

    }
}
