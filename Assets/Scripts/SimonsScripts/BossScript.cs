using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private enum Phase { Vulnerable, Invulnerable }
    Phase currentPhase;

    public Transform turretPrefab;

    public float turretsToSpawn;
    public bool turretsSpawned;
    public float turretsKilled;
    void Start()
    {


        currentPhase = Phase.Invulnerable;

        Instantiate(turretPrefab, new Vector3(-11, 1, 0), Quaternion.identity);
    }

    
    void Update()
    {
        SpawnTurrets();
    }

    private void SpawnTurrets()
    {
        if (currentPhase == Phase.Invulnerable && turretsSpawned == false)
        {

        }
    }
}
