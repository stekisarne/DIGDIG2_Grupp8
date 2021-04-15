using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] chunks; // All possible chunk prefabs
    [SerializeField] GameObject chunkParent; // GameObject with all chunks childed to it
    [SerializeField] GameObject currentChunk;
    public GameObject LoadedChunk;
    [SerializeField] GameObject chunkToLoad;
    public GameObject previousChunk;
    int distanceFromStart = 0; // Where currnt chunk is located on the y axis
    public ChunkScript chunkScript;
    public GameObject player;
    [SerializeField] int chunkSize; // How big the chunk is on the y axis
    int lastNumber; //ignore
    public static int chunkNumber; // What chunk it is. Used for difficulty scaling
    [SerializeField] StatSheet statsheet;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     LoadChunk();
        //     DeloadChunk();
        //  }

    }

    public void LoadChunk() // Loads new Chunk. Used in ChunkScript
    {
        previousChunk = currentChunk; // Makes currentChunk the previousChunk
        currentChunk = LoadedChunk; // Makes LoadedChunk the currentChunk

        Vector3 newPos;

        BoxCollider2D prevCollider = currentChunk.GetComponent<BoxCollider2D>();
        prevCollider.enabled = false; // Disables previous chunk spawn collider


        int i = Random.Range(0, chunks.Length); // gives i random value

        if (chunks.Length > 1)
        {
            while (i == lastNumber) // if i is same as last chunk number then re roll
            {
                i = Random.Range(0, chunks.Length);
            }
        }
        else if (chunks.Length == 1)
        {
            i = Random.Range(0, chunks.Length);
        }

        lastNumber = i;


        distanceFromStart = distanceFromStart - chunkSize; // changes distance from spawn depending on size of chunk

        newPos = new Vector3(0f, (float)distanceFromStart, 0f); // sets spawn point of next chunk to distanceFromStart

        chunkToLoad = chunks[i]; // makes chunkToLoad a random chunk based on i

        LoadedChunk = Instantiate(chunkToLoad, transform.position + newPos, Quaternion.identity, chunkParent.transform); // creates new chunk and assigns it to LoadedChunk

        chunkNumber++;

        statsheet.stage = chunkNumber;

        print("ChunkNumber: " + chunkNumber);

        chunkScript = LoadedChunk.GetComponent<ChunkScript>();

        print("loaded " + chunkToLoad.name);
    }

    public void LoadBossChunk()
    {

    }
}
