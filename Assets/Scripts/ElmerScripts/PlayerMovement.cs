using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    public GameObject groundCheck;
    public GameObject wallCheck;

    public enum PlayerCollisionState { ground, wall, none }
    PlayerCollisionState collisionState;

    public bool isFacingRight = true;

    float CurrentWalkCooldown;

    [Header("restrictions")]
    public float maxMoveSpeed;
    public float maxFallSpeed;

    [Header("stats")]
    public float moveSpeed;
    public float jumpForce;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float walkCooldown;


    // Start is called before the first frame update
    void Awake()
    {
        isFacingRight = true;
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        GravityAdjuster();
        if (CurrentWalkCooldown == 0)
        {
            Walk();
        }
        else
        {            
            WalkCooldown();
        }
        if (collisionState == PlayerCollisionState.ground)
        {
            Jump();
        } else if (collisionState == PlayerCollisionState.wall)
        {
            WallJump();
        }
        GroundWallCheck();
    }

    //set what the player is coliding with for the purpouses of jumping and wallclimbing
    void GroundWallCheck()
    { 
        if(groundCheck.GetComponent<GroundTrigger>().isTriggerd == true)
        { collisionState = PlayerCollisionState.ground;
            anim.SetBool("grounded",true);
        }
        else if (wallCheck.GetComponent<GroundTrigger>().isTriggerd == true)
        {collisionState = PlayerCollisionState.wall;
            anim.SetBool("grounded", false);
        }
        else
        {collisionState = PlayerCollisionState.none;
            anim.SetBool("grounded",false);}
    }

   
    // basic walking you get it
    public void Walk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.SetBool("walking", true);
            rBody.velocity = new Vector2 (Input.GetAxis("Horizontal") * moveSpeed, rBody.velocity.y);
            if (Input.GetAxis("Horizontal") >= 0)
            {
                isFacingRight = true;
                transform.rotation = new Quaternion (0, 0, 0, 0);
            }
            if (Input.GetAxis("Horizontal") <= 0)
            {
                isFacingRight = false;
                transform.rotation = new Quaternion (0, 180, 0, 0);
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    void WalkCooldown()
    {
        CurrentWalkCooldown = Mathf.Max(CurrentWalkCooldown - Time.deltaTime, 0);
    }

    // jump and potential jump resets
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.SetTrigger("jumping");
            rBody.velocity = Vector2.up * jumpForce;
        }
    }

    private void WallJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CurrentWalkCooldown = walkCooldown;
            if (isFacingRight == true)
            {
                transform.rotation = new Quaternion(0, 180, 0, 0);
                rBody.velocity = new Vector2(-jumpForce / 2, jumpForce / 1.5f);
                isFacingRight = false;
            }else if (!isFacingRight)
            {
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rBody.velocity = new Vector2(jumpForce / 2, jumpForce / 1.5f);
                isFacingRight = true;
            }
        }
    }

    void GravityAdjuster()
    {
        if (rBody.velocity.y < 0)
        {
            rBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } else if(rBody.velocity.y > 0 && !Input.GetButton("Jump"))
        {
            rBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
