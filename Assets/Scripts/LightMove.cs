using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.3f * Time.fixedDeltaTime, 0, 0));
    }
}
