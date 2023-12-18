using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ParticleAtFeetObjectPool : MonoBehaviour
{
    public GameObject record_prefabs;

    public int maxPoolSized = 10; //current pool size maximum
    public int stackDefaultCapacity = 5; //start pool size
                                          
    private IObjectPool<ScriptsParticleAtFeetHandler> _pool;
    public IObjectPool<ScriptsParticleAtFeetHandler> Pool
    {
        get
        {
            if (_pool == null)
            {
                _pool = new ObjectPool<ScriptsParticleAtFeetHandler>(CreatePooledItem, OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, true, stackDefaultCapacity, maxPoolSized);
            }
            return _pool;
        }
    }

    private ScriptsParticleAtFeetHandler CreatePooledItem()
    {
        GameObject go = Instantiate(record_prefabs, transform.position, Quaternion.identity);

        ScriptsParticleAtFeetHandler particleAtFeetScripts = go.GetComponent<ScriptsParticleAtFeetHandler>();
        particleAtFeetScripts.ParticleAtFeetPool = Pool;
        return particleAtFeetScripts;
    }

    private void OnTakeFromPool(ScriptsParticleAtFeetHandler particleAtFeetScripts)
    {
        particleAtFeetScripts.gameObject.SetActive(true);
    }
    private void OnReturnedToPool(ScriptsParticleAtFeetHandler particleAtFeetScripts)
    {
        particleAtFeetScripts.gameObject.SetActive(false);
    }
    private void OnDestroyPoolObject(ScriptsParticleAtFeetHandler particleAtFeetScripts)
    {
        Destroy(particleAtFeetScripts.gameObject);
    }
}
