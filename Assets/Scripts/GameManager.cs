using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
