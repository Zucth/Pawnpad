using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ScriptsParticleAtFeetHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    //private Animator gameObjectToFind;

    public IObjectPool<ScriptsParticleAtFeetHandler> ParticleAtFeetPool { get; set; }

    //public float moveSpeed = 10.0f;
    //[SerializeField] private Rigidbody rb;

    private void Start()
    {
        //animator = gameObjectToFind.GetComponent<Animator>;
    }

    private void Update() //play animation
    {
        //rb.velocity = Vector3.forward * moveSpeed;
        ReturnToPool();
    }

    private void ReturnToPool() //use this in animation state when it's end
    {
        //Debug.Log(animator.GetCurrentAnimatorStateInfo(0).IsName("RecordEffect_scan")); doesn't work
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("RecordEffect_Afterscan"))
        {
            ParticleAtFeetPool.Release(this);
        }

    }

    /* 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Wall"))
        {
            ReturnToPool();
        }
    }
    */


}
