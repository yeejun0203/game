using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public enum InfoType { Health, Score, MenuMaxScore, MenuCurScore }
    public InfoType type;

    TextMeshProUGUI myText;
    Slider mySlider;

    private void Awake()
    {
        myText = GetComponent<TextMeshProUGUI>();
        mySlider = GetComponent<Slider>();
    }
    private void LateUpdate()
    {
        switch (type)
        {
            case InfoType.Health:
                float curHealth = GameManager.instance.health;
                float maxHealth = GameManager.instance.maxHealth;
                mySlider.value = curHealth / maxHealth;
                break;
            case InfoType.Score:
                int score = GameManager.instance.gameScore;
                myText.text = string.Format("{0:n0}", score);
                break;
            case InfoType.MenuMaxScore:
                string maxScore = ScoreManager.instance.maxScore.ToString();
                myText.text = maxScore;
                break;
            case InfoType.MenuCurScore:
                string curScore = ScoreManager.instance.curScore.ToString();
                myText.text = curScore;
                break;
        }
    }
}
