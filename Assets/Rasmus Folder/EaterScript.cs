using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EaterScript : MonoBehaviour
{
    [SerializeField] GameObject Arrow;
    [SerializeField] GameObject player;
    float distanceBetweenEaterAndPlayer;
    void Update()
    {
        transform.Translate(0, -3 * Time.deltaTime, 0);

        distanceBetweenEaterAndPlayer = Mathf.Clamp(Vector2.Distance(gameObject.transform.position/50, player.transform.position/50), 0, 1.5f);

        Vector3 arrowSize = new Vector3(distanceBetweenEaterAndPlayer, distanceBetweenEaterAndPlayer);

        print("distance between: " + distanceBetweenEaterAndPlayer);
        print(arrowSize);

        Arrow.transform.localScale = arrowSize;
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
