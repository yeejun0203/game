using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 게임 속도
    public float gameLevel;
    // 게임이 시작했는지 아닌지
    public bool isGameStart;
    public GameObject player;
    // 게임 할 때 사용하는 시네마신
    public GameObject gameCamera;
    // GameManager.instance.player로 player가져오기 가능
    public static GameManager instance;

    private void Awake()
    {
        // 세팅
        instance = this;
    }

    public void ResetGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}
