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
        InvokeRepeating("AddGameLevel", 15f, 15f);
    }
    private void Update()
    {
        player.GetComponent<PlayerLogic>().jumpHeight = gameLevel;
        if (gameLevel < 12)
        {
            Physics.gravity = new Vector3(0, gameLevel * 2.2f * -1, 0);
        }
        else if (gameLevel < 16)
        {
            Physics.gravity = new Vector3(0, gameLevel * 2.6f * -1, 0);
        }
        else if (gameLevel < 20)
        {
            Physics.gravity = new Vector3(0, gameLevel * 3f * -1, 0);
        }
    }
    private void AddGameLevel()
    {
        gameLevel += 0.5f;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
