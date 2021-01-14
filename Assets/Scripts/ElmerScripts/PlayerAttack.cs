using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement movementScript;
    PlayerAnimationHandler anim;
    Animator swordAnim;
    private Rigidbody2D playerRB;
    private BoxCollider2D basicHB;
    float angle;
    float knockbackAngleX;
    float knockbackAngleY;
    bool isSlaming = false;
    public float slamVelocity;
    public float basicCD;
    float currentBasicCD;
    private EnemyHealth target;
    public float damage;

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
        BasicAttack();
        if (Input.GetButtonDown("Fire2") && !movementScript.isGrounded && !isSlaming)
        {
            isSlaming = true;
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
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            target = collision.GetComponent<EnemyHealth>();

            target.OnHit(damage);
        }
    }

    private void BasicAttack()
    {
        currentBasicCD = Mathf.Max(0, currentBasicCD - Time.deltaTime);
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("swing");
            SwordRotation();
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
            angle = Mathf.Atan2(knockbackAngleX, knockbackAngleY) * Mathf.Rad2Deg * -1 + 90;
        }
        else if (movementScript.isFacingRight)
        {
            angle = 0;
        }
        else { angle = 180; }
        

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
