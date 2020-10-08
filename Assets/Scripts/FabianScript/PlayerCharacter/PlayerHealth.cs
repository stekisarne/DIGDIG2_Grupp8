using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerHp;    //A variabel for the player health points.

    public void Awake()
    {
        playerHp = 100;
    }

    public void Death()
    {
        if(playerHp <= 0)   //I the player characters health goes under or is equal too 0 it destroyes the game object.
        {
            Destroy(this.gameObject);
        }
    }
}
