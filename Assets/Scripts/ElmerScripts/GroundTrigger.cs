using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTrigger : MonoBehaviour
{
    public bool isTriggerd;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            isTriggerd = true;
        } else
        {
            isTriggerd = false;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
            isTriggerd = false;        
    }

}
