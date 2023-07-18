using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // GameManager.instance.player로 player가져오기 가능
    public static GameManager instance;
    [Header("### Game Info")]
    public float gameLevel; // 게임 속도
    public int gameScore;
    public bool isGameStart; // 게임이 시작했는지 아닌지
    public GameObject gameCamera; // 게임 할 때 사용하는 시네마신
    public GameObject gameOverPanel;

    [Header("### Player Info")]
    public GameObject player;
    public float maxHealth; // 최대 체력
    public float health; // 현재 체력

    public GameObject obstacles;

    private void Awake()
    {
        // 세팅
        instance = this;
    }
    private void Start()
    {
        health = maxHealth;
        InvokeRepeating("AddGameLevel", 15f, 15f);
    }
    private void Update()
    {
        if (player.GetComponent<PlayerLogic>().isLive == false) return;
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
        gameLevel += 0.5f;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void BkMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
