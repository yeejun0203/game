using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MySceneManager : MonoBehaviour
{
    public CanvasGroup fadeImg;
    [SerializeField] float fadeDuration = 2;

    public static MySceneManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static MySceneManager instance;

    void Start()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void ChangeScene()
    {
        fadeImg.DOFade(1, fadeDuration)
            .OnStart(() => {
                fadeImg.blocksRaycasts = true; //�Ʒ� ����ĳ��Ʈ ����
            })
            .OnComplete(() => {
                SceneManager.LoadScene("GameScene");
            });
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // �̺�Ʈ���� ����*
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        fadeImg.DOFade(0, fadeDuration)
        .OnComplete(() => {
            fadeImg.blocksRaycasts = false;
        });
    }

}
