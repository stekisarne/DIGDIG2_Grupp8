using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationHandler : MonoBehaviour
{

    Animator anim;

    public string currentState;

    public bool walking;
    public bool jumping;
    public bool falling;
    public bool grounded;
    public bool dashing;
    public bool attacking;
    public bool slaming;

    // Start is called before the first frame update
    void Start()
    {
       anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (slaming) ChangeAnimationState("slam");
        else if (dashing) ChangeAnimationState("dash");
        else if (attacking) ChangeAnimationState("attack");
        else if (jumping) ChangeAnimationState("jump");
        else if (falling) ChangeAnimationState("falling");
        else if (walking) ChangeAnimationState("walk");
        else ChangeAnimationState("idle");

    }
    public void ChangeAnimationState(string newState)
    {
        if (currentState == newState) return;

        anim.Play("player " + newState);
        //Debug.Log("player " + newState);

        currentState = newState;
    }

}
