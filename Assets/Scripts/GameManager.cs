using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // GameManager.instance.player�� player�������� ����
    public static GameManager instance;
    [Header("### Game Info")]
    public float gameLevel; // ���� �ӵ�
    public bool isGameStart; // ������ �����ߴ��� �ƴ���
    public GameObject gameCamera; // ���� �� �� ����ϴ� �ó׸���

    [Header("### Player Info")]
    public GameObject player;
    public float maxHealth; // �ִ� ü��
    public float health; // ���� ü��

    private void Awake()
    {
        // ����
        instance = this;
    }
    private void Start()
    {
        health = maxHealth;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
