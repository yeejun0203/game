using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� �ӵ�
    public float gameLevel;
    // ������ �����ߴ��� �ƴ���
    public bool isGameStart;
    public GameObject player;
    // ���� �� �� ����ϴ� �ó׸���
    public GameObject gameCamera;
    // GameManager.instance.player�� player�������� ����
    public static GameManager instance;

    private void Awake()
    {
        // ����
        instance = this;
    }
}
