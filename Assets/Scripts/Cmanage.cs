using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cmanage : MonoBehaviour
{
    private Vector3 dir = Vector3.zero;
    private void Update()
    {
        dir.z = GameManager.instance.gameLevel;
    }
    void FixedUpdate()
    {
        // 실제 위치 이동
        transform.position += dir * Time.fixedDeltaTime;
    }
}
