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
    public bool isGameStart; // 게임이 시작했는지 아닌지
    public GameObject gameCamera; // 게임 할 때 사용하는 시네마신

    [Header("### Player Info")]
    public GameObject player;
    public float maxHealth; // 최대 체력
    public float health; // 현재 체력

    private void Awake()
    {
        // 세팅
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
