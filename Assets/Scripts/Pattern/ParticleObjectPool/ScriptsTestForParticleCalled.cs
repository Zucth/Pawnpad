using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsTestForParticleCalled : MonoBehaviour
{
    [SerializeField] ParticleAtFeetObjectPool ParticleAtFeetPool;
    [SerializeField] private Transform ParticleSpawnpoint;
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        ScriptsParticleAtFeetHandler particleAtFeetScripts = ParticleAtFeetPool.Pool.Get(); 

        particleAtFeetScripts.transform.position = ParticleSpawnpoint.transform.position;
        //particleAtFeetScripts.transform.rotation = ParticleSpawnpoint.rotation;
    }
}
