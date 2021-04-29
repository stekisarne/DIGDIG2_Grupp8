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

    [Header("SFX")]
    public GameObject swingSFX;
    public GameObject SlamStartSFX;
    public GameObject SlamLandSFX;
    public GameObject stepSFX;
    public GameObject jumpSFX;
    public GameObject landSFX;
    public GameObject dashSFX;
    public GameObject shieldBreakSFX;
    public GameObject deathSFX;

    [Header("ParticleFX")]
    public GameObject slamParticle;
    public GameObject stepParticle;
    public GameObject dashParticle;
    public GameObject shieldBreakParticle;
    public GameObject deathParticle;

    [Header("PFX Locations")]
    public GameObject groundParticleLocation;

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

    public void FXSlamLand()
    {
        Instantiate(SlamLandSFX, transform.parent);
        Instantiate(slamParticle, groundParticleLocation.gameObject.transform);
    }

    public void FXJump()
    {
        Instantiate(jumpSFX, transform.parent);
    }

    public void FXStep()
    {
        Instantiate(stepSFX, transform.parent);
    }

    public void FXDash()
    {
        Instantiate(dashSFX, transform.parent);
    }

    public void FXSwing()
    {
        Instantiate(swingSFX, transform.parent);
    }

    public void FXLand()
    {
        Instantiate(landSFX, transform.parent);
    }
}
