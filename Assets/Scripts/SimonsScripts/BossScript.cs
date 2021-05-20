using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
    private enum Phase { Vulnerable, Invulnerable }
    Phase currentPhase;

    VeinHandlerScript veinHandler;

    public float damageTaken;
    void Start()
    {
        veinHandler = FindObjectOfType<VeinHandlerScript>();

        
    }

    
    void Update()
    {
        SetPhase();
        
        BossDeath();
        
    }

    

    void SetPhase()
    {
        if (veinHandler.VeinCount == 0)
        {
            
            veinHandler.SpawnVeins();
            
        }

        
    }

    

    void BossDeath()
    {
        if(veinHandler.VeinsKilled == 14f)
        {
            Destroy(this.gameObject);
        }
    }
}
