using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossScript : MonoBehaviour
{
   
    VeinHandlerScript veinHandler;

    public float bossHealth;
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
            bossHealth -= 1f;
            veinHandler.SpawnVeins();
        }

    }

    

    void BossDeath()
    {
        if(bossHealth == 0f)
        {
            Destroy(this.gameObject);
        }
    }
}
