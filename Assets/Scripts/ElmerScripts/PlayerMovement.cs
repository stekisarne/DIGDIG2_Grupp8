using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rBody;
    private Animator anim;

    public enum PlayerState { Moving, Fighting, Idling }
    PlayerState currentState;
    // currentstate = PlayerState.Idling;

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

    void GroundWallCheck()
    {
        
    }

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

    public void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            //anim.SetBool("jumping",true);
            rBody.velocity = new Vector2(rBody.velocity.x, jumpForce);
        }
    }
}
