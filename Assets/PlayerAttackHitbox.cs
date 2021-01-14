using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHitbox : MonoBehaviour
{
    public float damage;
   

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggernter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Debug.Log("onHit");
            
        }
    }

}
