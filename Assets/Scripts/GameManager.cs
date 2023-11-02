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
    public int gameScore;
    public bool isGameStart; // ������ �����ߴ��� �ƴ���
    public GameObject gameCamera; // ���� �� �� ����ϴ� �ó׸���
    public GameObject gameOverPanel;

    [Header("### Player Info")]
    public GameObject player;
    public float maxHealth; // �ִ� ü��
    public float health; // ���� ü��

    public GameObject obstacles;

    public bool isHardMod; // �ϵ� ���

    private void Awake()
    {
        // ����
        instance = this;
    }
    private void Start()
    {
        isHardMod = MySceneManager.Instance.hardSet;
#if UNITY_ANDROID
        Application.targetFrameRate = 120;
#endif
        health = maxHealth;
        if (isHardMod)
        {
            InvokeRepeating("AddGameLevel", 8f, 8f);
        }
        else
        {
            InvokeRepeating("AddGameLevel", 13f, 13f);
        }

    }
    private void Update()
    {
        if (player.GetComponent<PlayerLogic>().isLive == false) return;
        player.GetComponent<PlayerLogic>().jumpHeight = gameLevel;
        if (gameLevel < 16)
        {
            Physics.gravity = new Vector3(0, gameLevel * 2.6f * -1, 0);
        }
        else if (gameLevel < 20)
        {
            Physics.gravity = new Vector3(0, gameLevel * 3f * -1, 0);
        }
        else if (gameLevel < 25)
        {
            Physics.gravity = new Vector3(0, gameLevel * 3.5f * -1, 0);
        }
        else if (gameLevel < 30) 
        {
            Physics.gravity = new Vector3(0, gameLevel * 4f * -1, 0);
        }
        else if (gameLevel < 35)
        {
            Physics.gravity = new Vector3(0, gameLevel * 4.5f * -1, 0);
        }
        else
        {
            Physics.gravity = new Vector3(0, gameLevel * 5f * -1, 0);
        }
    }
    private void AddGameLevel()
    {
        if(isHardMod)
        {
            gameLevel += 0.7f;
        }
        else
        {
            gameLevel += 0.5f;
        }
    }

    public void ResetGame()
    {
        MySceneManager.Instance.ChangeScene("GameScene");
    }

    public void BkMenu()
    {
        MySceneManager.Instance.ChangeScene("MenuScene");
    }
}
