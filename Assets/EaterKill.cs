using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterKill : MonoBehaviour
{
    public PlayerHpScript playerHp;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            playerHp.PlayerHit();
        }
    }
}
