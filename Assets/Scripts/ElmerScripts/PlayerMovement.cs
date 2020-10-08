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

    float walkCooldown;

    [Header("restrictions")]
    public float maxMoveSpeed;
    public float maxFallSpeed;

    [Header("stats")]
    public float moveSpeed;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        isFacingRight = true;
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(isFacingRight);
        if (walkCooldown == 0)
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
        { collisionState = PlayerCollisionState.ground;}
        else if (wallCheck.GetComponent<GroundTrigger>().isTriggerd == true)
        {collisionState = PlayerCollisionState.wall; }
        else
        {collisionState = PlayerCollisionState.none; }
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
        walkCooldown = Mathf.Max(walkCooldown - Time.deltaTime, 0);
    }

    // jump and potential jump resets
    public void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        }
    }

    private void WallJump()
    {
        if (Input.GetKeyDown("space"))
        {
            walkCooldown = 0.4f;
            if (isFacingRight == true)
            {
                Debug.Log("right walljump");
                transform.rotation = new Quaternion(0, 180, 0, 0);
                rBody.velocity = new Vector2(-jumpForce / 2, jumpForce / 1.5f);
                isFacingRight = false;
            }else if (!isFacingRight)
            {
                Debug.Log("left walljump");
                transform.rotation = new Quaternion(0, 0, 0, 0);
                rBody.velocity = new Vector2(jumpForce / 2, jumpForce / 1.5f);
                isFacingRight = true;
            }
        }
    }
}
