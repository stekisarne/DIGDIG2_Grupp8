using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterScript : MonoBehaviour
{

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(0, -3 * Time.deltaTime, 0);
    }

    void EatChunk(GameObject ChunkToDestroy)
    {
        Destroy(ChunkToDestroy, 5f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Chunk")
        {
            print("chunker");
            EatChunk(other.gameObject);
        }
    }
}
