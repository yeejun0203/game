using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    Vector3 gameStartVec = Vector3.zero;

    void Awake()
    {
        // ���� �ʱ�ȭ
        gameStartVec = new Vector3(0, 12, -12);
    }
    private void Update()
    {
        // �ó׸��� �ٲٱ�
        if (Mathf.Abs(transform.position.y - gameStartVec.y) < 0.1f)
        {
            GameManager.instance.gameCamera.SetActive(true);
            GameManager.instance.isGameStart = true;
            gameObject.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        // �ε巯�� ī�޶� �̵�
        Vector3 velo = Vector3.zero;
        transform.position = Vector3.SmoothDamp(transform.position, gameStartVec, ref velo, 0.16f);
    }
}
