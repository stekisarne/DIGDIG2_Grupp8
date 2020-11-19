using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject whatToSpawn;
    public int chanceToSpawn;
    void Start()
    {
        int i = 0;

        i = Random.Range(0, 101);

        if(i <= chanceToSpawn)
        {
            Instantiate(whatToSpawn, transform.position, Quaternion.identity, transform);
        }
    }
}
