using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchasable : MonoBehaviour
{

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {

        }
    }
}
