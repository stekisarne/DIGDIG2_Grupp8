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
        if (collision.tag == "Player" && collision == col) // If trigger is Player and main Player BoxCollider2D
        {
            print("triggerd collision");
            chunkManagerScript.LoadChunk(); // Loads new chunk
            Physics2D.IgnoreCollision(collision, GetComponent<Collider2D>()); // Ignores every collision after first one
        }
    }
}

