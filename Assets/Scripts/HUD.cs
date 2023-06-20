using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public enum InfoType { Health }
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
        }
    }
}
