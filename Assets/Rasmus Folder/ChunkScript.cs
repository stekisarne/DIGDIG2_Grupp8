using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkScript : MonoBehaviour
{
    [SerializeField] GameObject[] chunks;
    [SerializeField] GameObject chunkParent;
    [SerializeField] GameObject currentChunk;
    public GameObject LoadedChunk;
    GameObject chunkToLoad;
    GameObject previousChunk;
    int distanceFromStart = 0;
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LoadChunk();
            DeloadChunk();
        }

    }

    void LoadChunk()
    {
        int i;

        Vector3 newPos;

        distanceFromStart = distanceFromStart - 20;

        i = Random.Range(0, chunks.Length);

        newPos = new Vector3(0f, (float)distanceFromStart, 0f);

        chunkToLoad = chunks[i];

        LoadedChunk = Instantiate(chunkToLoad, transform.position + newPos, Quaternion.identity, chunkParent.transform);

        print("loaded " + chunkToLoad.name);
    }

    void DeloadChunk()
    {
        previousChunk = currentChunk;
        currentChunk = LoadedChunk;
        print("Deloaded " + previousChunk);
        Destroy(previousChunk);

    }
}
