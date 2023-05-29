using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmanage : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    private Vector3 dir = Vector3.zero;
    /*void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    */
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        dir.z = GameManager.instance.gameLevel;
    }
    void FixedUpdate()
    {
        // 실제 위치 이동
        rb.MovePosition(transform.position + dir * Time.fixedDeltaTime);
    }
}
