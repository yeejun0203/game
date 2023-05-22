using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 게임 속도
    public float gameLevel;
    public GameObject player;

    // GameManager.instance.player로 player가져오기 가능
    public static GameManager instance;

    private void Awake()
    {
        // 세팅
        instance = this;
    }
}
