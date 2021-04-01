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
        MakeInvulnerable();
        BossDeath();
    }

    

    void SetPhase()
    {
        if (veinHandler.VeinCount == 0 && currentPhase == Phase.Invulnerable)
        {
            Invoke("veinHandler.SpawnVeins", 10f);
            
            currentPhase = Phase.Vulnerable;
        }
        else if(currentPhase == Phase.Vulnerable)
        {
            
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    void MakeInvulnerable()
    {
        if(veinHandler.VeinCount > 0)
        {
            currentPhase = Phase.Invulnerable;
        }

        if(currentPhase == Phase.Invulnerable)
        {
            GetComponent<BoxCollider2D>().enabled = false;
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
