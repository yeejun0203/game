using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    private void Start()
    {
        ScoreManager.instance.LoadScore();
    }

    public void StartGame() => MySceneManager.Instance.ChangeScene("GameScene");
    public void OptionMenu() => MySceneManager.Instance.ChangeScene("Option");
}
