using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolInitialize : MonoBehaviour
{
    private void OnDisable()
    {
        transform.position = Vector3.zero;
    }
}
