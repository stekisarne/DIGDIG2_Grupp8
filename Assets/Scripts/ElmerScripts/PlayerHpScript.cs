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
        if (Hp > 1)
        {
            iFramesLeft = iFrames;
            Instantiate(hitParticle, transform.parent);
            Hp -= 1;
            UIHPDisplay.text = ("" + Hp);
        } else
        {
            Death();
        }
    }
    void Death()
    {
        Hp -= 1;
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
