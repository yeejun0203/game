using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 gameStartVec = Vector3.zero;

    void Awake()
    {
        // 벡터 초기화
        gameStartVec = new Vector3(0, 12, -12);
    }
    private void Update()
    {
        // 시네마신 바꾸기
        if (Mathf.Abs(transform.position.y - gameStartVec.y) < 0.1f)
        {
            GameManager.instance.gameCamera.SetActive(true);
            GameManager.instance.isGameStart = true;
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        // 부드러운 카메라 이동
        Vector3 velo = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, gameStartVec, ref velo, 0.16f);
    }
}
