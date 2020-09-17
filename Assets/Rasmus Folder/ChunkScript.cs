using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    [SerializeField] ChunkManagerScript chunkManagerScript;

    private void Start()
    {
        chunkManagerScript = GameObject.FindGameObjectWithTag("ChunkHandler").transform.GetComponent<ChunkManagerScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        chunkManagerScript.LoadChunk();
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //chunkManagerScript.DeloadChunk();
    }

}
