using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Security.Cryptography;

public class ScoreManager : MonoBehaviour
{
    Score score = new Score();
    string filePath;
    public float maxScore;
    public float curScore;

    private static string privateKey;

    public static ScoreManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            privateKey = SystemInfo.deviceUniqueIdentifier.Replace("-", string.Empty);
        }
    }
    private void Start()
    {
        filePath = Application.persistentDataPath + "/MyScore.txt";
        Debug.Log(filePath);
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

    //////////////////////////////////////////////////////////////////////////////
    
    // ���� ù ���� ������ ����
    public void ResetScore()
    {
        score.maxScore = 0;
        string scoreData = JsonUtility.ToJson(score);
        string encryptScoreData = Encrypt(scoreData);
        File.WriteAllText(filePath, encryptScoreData);
        LoadScore();
    }

    // ���ھ� ���� (�̹� ����� ���ھ�� ������ ����)
    public void SaveScore(int _score)
    {
        if (maxScore >= _score) return;
        score.maxScore = _score;
        string scoreData = JsonUtility.ToJson(score);
        string encryptScoreData = Encrypt(scoreData);
        File.WriteAllText(filePath, encryptScoreData);
    }

    // ���ھ� �ҷ����� (�ְ����� �ҷ�����)
    public void LoadScore()
    {
        if (!File.Exists(filePath)) { ResetScore(); return; }

        string encryptScoreData = File.ReadAllText(filePath);
        string dycryptScoreData = Decrypt(encryptScoreData);
        score = JsonUtility.FromJson<Score>(dycryptScoreData);
        maxScore = score.maxScore;
    }

    /////////////////////////////////////////////////////////////////////////////
    // ���⼭���� ������ ��ȣȭ �ڵ� (���� �� �����)
    ///
    private string Encrypt(string data)
    {

        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateEncryptor();
        byte[] results = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Convert.ToBase64String(results, 0, results.Length);

    }

    private string Decrypt(string data)
    {

        byte[] bytes = System.Convert.FromBase64String(data);
        RijndaelManaged rm = CreateRijndaelManaged();
        ICryptoTransform ct = rm.CreateDecryptor();
        byte[] resultArray = ct.TransformFinalBlock(bytes, 0, bytes.Length);
        return System.Text.Encoding.UTF8.GetString(resultArray);
    }


    private RijndaelManaged CreateRijndaelManaged()
    {
        byte[] keyArray = System.Text.Encoding.UTF8.GetBytes(privateKey);
        RijndaelManaged result = new RijndaelManaged();

        byte[] newKeysArray = new byte[16];
        System.Array.Copy(keyArray, 0, newKeysArray, 0, 16);

        result.Key = newKeysArray;
        result.Mode = CipherMode.ECB;
        result.Padding = PaddingMode.PKCS7;
        return result;
    }
    ///////////////////////////////////////////////////////////////
}

// ���ھ� Ŭ���� ����
class Score
{
    public float maxScore;
}
