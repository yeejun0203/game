using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rangemove : MonoBehaviour
{
    Vector3 position;
    public GameObject r;
    public float speed;

    void start()
    {
        position = transform.position;
    }

    void Update()
    {
        position.z += speed * Time.deltaTime;

        transform.position = position;
    }
}
