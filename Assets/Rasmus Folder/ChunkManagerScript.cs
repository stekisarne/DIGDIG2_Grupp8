using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManagerScript : MonoBehaviour
{
    [SerializeField] GameObject[] chunks;
    [SerializeField] GameObject chunkParent;
    [SerializeField] GameObject currentChunk;
    public GameObject LoadedChunk;
    [SerializeField] GameObject chunkToLoad;
    public GameObject previousChunk;
    int distanceFromStart = 0;
    public ChunkScript chunkScript;
    public GameObject player;
    [SerializeField] int chunkSize;
    int lastNumber;

    void Start()
    {

        
    }

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
       // {
       //     LoadChunk();
       //     DeloadChunk();
      //  }
        
    }

    public void LoadChunk()
    {
        previousChunk = currentChunk;
        currentChunk = LoadedChunk;

        Vector3 newPos;

        BoxCollider2D prevCollider = currentChunk.GetComponent<BoxCollider2D>();
        prevCollider.enabled = false;


        int i = Random.Range(0, chunks.Length);

        while (i == lastNumber)
        {
            i = Random.Range(0, chunks.Length);
        }

        lastNumber = i;


        distanceFromStart = distanceFromStart - chunkSize;

        newPos = new Vector3(0f, (float)distanceFromStart, 0f);

        chunkToLoad = chunks[i];

        LoadedChunk = Instantiate(chunkToLoad, transform.position + newPos, Quaternion.identity, chunkParent.transform);

        chunkScript = LoadedChunk.GetComponent<ChunkScript>();

        print("loaded " + chunkToLoad.name);
    }

    public void DeloadChunk()
    {
        previousChunk = currentChunk;
        currentChunk = LoadedChunk;
        print("Deloaded " + previousChunk);
        Destroy(previousChunk);

    }
}
