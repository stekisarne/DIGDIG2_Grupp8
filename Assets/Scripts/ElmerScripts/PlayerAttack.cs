using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement movementScript;
    private Rigidbody2D playerRB;
    private BoxCollider2D basicHB;
    float angle;
    Vector2 knockbackAngle;
    public float basicActiveTime;
    public float basicCD;
    float currentBasicActiveTime;
    float currentBasicCD;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponentInParent<Rigidbody2D>();
        movementScript = GetComponentInParent<PlayerMovement>();
        basicHB = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        BasicAttack();
        if (Input.GetButtonDown("Fire2"))
        {
            movementScript.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("hit");
        }
    }

    private void BasicAttack()
    {
        currentBasicActiveTime = Mathf.Max(0, currentBasicActiveTime - Time.deltaTime);
        currentBasicCD = Mathf.Max(0, currentBasicCD - Time.deltaTime);
        if (Input.GetButtonDown("Fire1") && currentBasicActiveTime == 0)
        {
            Debug.Log("swing");
            SwordRotation();
            currentBasicCD = basicCD + basicActiveTime;
            currentBasicActiveTime = basicActiveTime;
        }
        if (currentBasicActiveTime == 0)
        {
            basicHB.enabled = false;
        }
        else
        {
            basicHB.enabled = true;
        }
       
    }

    private void SwordRotation()
    {
        if (Input.GetAxis("Vertical") != 0)
        {
            angle = Mathf.Atan2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * Mathf.Rad2Deg * -1 + 90;
        }
        else if (movementScript.isFacingRight)
        {
            angle = 0;
        }
        else { angle = 180; }
        

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
