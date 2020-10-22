using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    ChunkManagerScript chunkManagerScript;
    BoxCollider2D col;
    private void Awake()
    {
        col = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider2D>();
        chunkManagerScript = GameObject.FindGameObjectWithTag("ChunkHandler").transform.GetComponent<ChunkManagerScript>();
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && collision == col)
        {
            print("triggerd collision");
            chunkManagerScript.LoadChunk();
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>());
        }
    }
}

