using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    Score score = new Score();
    string filePath;
    public float maxScore;

    public static ScoreManager instance;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        filePath = Application.persistentDataPath + "/MyScore.json";
        var obj = FindObjectsOfType<ScoreManager>();
        if (obj.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ResetScore()
    {
        SaveScore(0);
        LoadScore();
    }
    public void SaveScore(int _score)
    {
        score.maxScore = _score;
        string scoreData = JsonUtility.ToJson(score);
        File.WriteAllText(filePath, scoreData);
    }

    public void LoadScore()
    {
        if (!File.Exists(filePath)) { ResetScore(); return; }

        string scoreData = File.ReadAllText(filePath);
        score = JsonUtility.FromJson<Score>(scoreData);
        maxScore = score.maxScore;
    }
}

class Score
{
    public float maxScore;
}
