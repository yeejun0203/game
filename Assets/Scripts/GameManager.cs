using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ���� �ӵ�
    public float gameLevel;
    public GameObject player;

    // GameManager.instance.player�� player�������� ����
    public static GameManager instance;

    private void Awake()
    {
        // ����
        instance = this;
    }
}
