using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerMovement movementScript;
    PlayerAnimationHandler anim;
    Animator swordAnim;
    private Rigidbody2D playerRB;
    private BoxCollider2D basicHB;
    public CircleCollider2D SlamHB;
    float angle;
    float knockbackAngleX;
    float knockbackAngleY;
    bool isSlaming = false;
    public float slamVelocity;
    public float basicCD;
    public float lungeDamper = 150;
    float currentBasicCD;
    private EnemyHealth target;
    public float damage;
    private Vector2 knockbackAngle;
    public float knockbackForce = 3;
    public float selfKnockbackForce = 3;

    // Start is called before the first frame update
    void Start()
    {
        swordAnim = GetComponent<Animator>();
        anim = GetComponentInParent<PlayerAnimationHandler>();
        playerRB = GetComponentInParent<Rigidbody2D>();
        movementScript = GetComponentInParent<PlayerMovement>();
        basicHB = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isslaming is " +isSlaming);
        if (isSlaming == false)
        {
            StartBasicAttack();
        }
        if (Input.GetButtonDown("Fire2") && !movementScript.isGrounded && !isSlaming)
        {
            isSlaming = true;
            SlamHB.enabled = true;
            Debug.Log("Start Slam");
            playerRB.velocity = new Vector2(0, -slamVelocity);
        }
        if (isSlaming)
        {
            Slaming();
        }
    }

    private void Slaming()
    {
        movementScript.enabled = false;
        playerRB.AddForce(new Vector2(0,-slamVelocity));
        if(playerRB.velocity.y == 0)
        {
            Debug.Log("Stop Slam");
            movementScript.enabled = true;
            isSlaming = false;
            SlamHB.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            target = collision.GetComponent<EnemyHealth>();
            if (target != null)
            {
                playerRB.velocity = Vector2.zero;
                playerRB.AddForce(-knockbackAngle * selfKnockbackForce, ForceMode2D.Impulse);
                target.OnHit(damage, knockbackAngle, knockbackForce);
            }
        }
    }

    private void StartBasicAttack()
    {
        currentBasicCD = Mathf.Max(0, currentBasicCD - Time.deltaTime);
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
        movementScript.canTurn = true;
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
