using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyParticleAfterLoop : MonoBehaviour
{

    ParticleSystem particleSystem;
    float dur;
    void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        Destroy(gameObject, particleSystem.main.duration);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
