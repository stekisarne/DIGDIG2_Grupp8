using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    public enum PlayerCollisionState { ground, left, right, none }
    PlayerCollisionState collisionState;

    // collisionState = PlayerCollisionState.ground;

    /* 
    if (collisionState == PlayerState.ground)
    {
    
        }
        
        */

    [Header("restrictions")]
    public float maxMoveSpeed;
    public float maxFallSpeed;

    [Header("stats")]
    public float moveSpeed;
    public float jumpForce;


    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Walk();
        Jump();
        GroundWallCheck();
    }

    //set what the player is coliding with for the purpouses of jumping and wallclimbing
    void GroundWallCheck()
    {
        RaycastHit2D downHit = Physics2D.Raycast(this.gameObject.transform.position, -Vector2.up, 1f); // this shit dont work
        if (downHit.collider.tag == "Untagged")
        {
            collisionState = PlayerCollisionState.ground;
            Debug.Log(collisionState);
        }
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
                transform.rotation = new Quaternion (0, 0, 0, 0);
            }
            if (Input.GetAxis("Horizontal") <= 0)
            {
                transform.rotation = new Quaternion (0, 180, 0, 0);
            }
        }
        else
        {
            anim.SetBool("walking", false);
        }
    }

    // jump and potential jump resets
    public void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            //anim.SetBool("jumping",true);
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        }
    }
}
