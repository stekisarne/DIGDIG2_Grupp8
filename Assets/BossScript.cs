using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private enum Phase { Vulnerable, Invulnerable }
    Phase currentPhase;

    public float turretsToSpawn;
    void Start()
    {
        currentPhase = Phase.Invulnerable;
    }

    
    void Update()
    {
        if(currentPhase == Phase.Invulnerable)
        {

        }
    }
}
