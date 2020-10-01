using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    ChunkManagerScript chunkManagerScript;
    private void Awake()
    {
        chunkManagerScript = GameObject.FindGameObjectWithTag("ChunkHandler").transform.GetComponent<ChunkManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            chunkManagerScript.LoadChunk();
        }
    }
}
