using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rBody;
    private PlayerAnimationHandler anim;

    public GameObject groundCheck;
    public GameObject wallCheck;
    private float coyoteTime;

    public enum PlayerCollisionState { ground, wall, none }
    PlayerCollisionState collisionState;
    private float collisionStateUpdateCD;

    public bool isFacingRight = true;
    public bool isGrounded;
    public float currentWalkCooldown;

    [Header("stats")]
    public float moveSpeed;
    public float jumpForce;
    public int airJumps = 0;
    private int remainingJumps;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float walkCooldown;


    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<PlayerAnimationHandler>();
        isFacingRight = true;
        rBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
        GravityAdjuster();
        if (currentWalkCooldown == 0)
        {
            Walk();
        }
        else
        {
            WalkCooldown();
        }
        if (isGrounded == true)
        {
            Jump();
        }
        else if (collisionState == PlayerCollisionState.wall)
        {
            WallJump();
        } else if (remainingJumps > 0)
        {
            Jump();
        }
        GroundWallCheck();
        FallCheck();
        PlayerLookDir();
    }

   

    //set what the player is coliding with for the purpouses of jumping and wallclimbing
    void GroundWallCheck()
    { 
        if(groundCheck.GetComponent<GroundTrigger>().isTriggerd == true)
        {
            if (collisionStateUpdateCD == 0)
            {
                collisionState = PlayerCollisionState.ground;
                anim.grounded = true;
                isGrounded = true;
                coyoteTime = 0.15f;
                remainingJumps = airJumps;
            } else
            {
                collisionStateUpdateCD = Mathf.Max(0, collisionStateUpdateCD - Time.deltaTime);
            }
        }
        else if (wallCheck.GetComponent<GroundTrigger>().isTriggerd == true)
        {collisionState = PlayerCollisionState.wall;
            anim.grounded = false;
            isGrounded = false;
            remainingJumps = airJumps;
        }
        else
        {collisionState = PlayerCollisionState.none;
            if (coyoteTime == 0)
            {
                anim.grounded = false;
                isGrounded = false;
            }
            else
            {
                coyoteTime = Mathf.Max(0, coyoteTime - Time.deltaTime);
            }
        }
    }

   
    // basic walking you get it
    public void Walk()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            anim.walking = true;
            rBody.AddForce(new Vector2(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime,0));
           
        }
        else
        {
            anim.walking = false;
        }
    }

    void WalkCooldown()
    {
        currentWalkCooldown = Mathf.Max(currentWalkCooldown - Time.deltaTime, 0);
    }

    // jump and potential jump resets
    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            anim.jumping = true;
            coyoteTime = 0;
            collisionStateUpdateCD = 0.1f;
            rBody.velocity = new Vector2(rBody.velocity.x, 0);
            rBody.AddForce(transform.up * jumpForce);
            if (!isGrounded)
            {
                remainingJumps -= 1;
            }
        }
    }
    void FallCheck()
    {
        if (rBody.velocity.y <= 0.1)
        {
            anim.jumping = false;
            if (!isGrounded)
            {
                anim.falling = true;
            }
            else { anim.falling = false; }
        } else { anim.falling = false; }
    }
    

    private void WallJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            currentWalkCooldown = walkCooldown;
            if (isFacingRight == true)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, 0);
                rBody.AddForce (-transform.right * jumpForce / 2 + transform.up * jumpForce );
                isFacingRight = false;
            }else if (!isFacingRight)
            {
                rBody.velocity = new Vector2(rBody.velocity.x, 0);
                rBody.AddForce(-transform.right * jumpForce / 2 + transform.up * jumpForce );
                isFacingRight = true;
            }
        }
    }

    private void PlayerLookDir()
    {
        if (rBody.velocity.x >= 0.3f)
        {
            isFacingRight = true;
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        if (rBody.velocity.x <= -0.3f)
        {
            isFacingRight = false;
            transform.rotation = new Quaternion(0, 180, 0, 0);
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
