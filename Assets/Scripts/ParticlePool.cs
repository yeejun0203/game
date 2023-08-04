using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePool : MonoBehaviour
{
    void Update()
    {
        if(!GetComponent<ParticleSystem>().isPlaying)
        {
            ObjectPool.ReturnObjectToPool(gameObject);
        }
    }
}
