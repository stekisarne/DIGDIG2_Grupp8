using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerHpScript : MonoBehaviour
{

    public int Hp;
    public int iFrames;

    private int iFramesLeft;

    public GameObject player;
    private CircleCollider2D hitBox;
    public Text UIHPDisplay;
    public GameObject hitParticle;
    public GameObject deathParticle;
    public GameObject sfx;
    public Animator UIanim;


    [Header("disable on death")]
    public PlayerAttack playerattack;
    public PlayerAnimationHandler PlayerAnimationHandler;
    public PlayerMovement playerMovement;
    public Dash dash;
    public SpriteRenderer playerSprite;

    // Start is called before the first frame update
    void Start()
    {
        UIHPDisplay.text = ("" + Hp);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIFrames();
        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerHit();
        }
    }

    //called when player is hit
    public void PlayerHit()
    {
        if (iFramesLeft <= 0)
        {
            if (Hp > 1)
            {
                UIanim.Play("UIHurt");
                iFramesLeft = iFrames;
                Instantiate(hitParticle, transform.parent);
                Hp -= 1;
                UIHPDisplay.text = ("" + Hp);
            }
            else if (Hp == 1)
            {
                Death();
            }
        }
    }
    void Death()
    {
        PlayerAnimationHandler.enabled = false;
        playerattack.enabled = false;
        playerMovement.enabled = false;
        dash.enabled = false;
        playerSprite.enabled = false;
        UIanim.Play("UIDeath");
        Hp = 0;
        UIHPDisplay.text = ("" + Hp);
        Instantiate(deathParticle, gameObject.transform);
    }

   
    private void UpdateIFrames()
    {
        if (iFrames > 0)
        {
            hitBox.enabled = false;
            iFramesLeft -= 1;
        }
    }
}
