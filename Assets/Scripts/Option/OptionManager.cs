using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour
{
    public GameObject toggle;

    private void Update()
    {
        toggle.GetComponent<Toggle>().isOn = MySceneManager.Instance.hardSet;
    }

    public void HardSet(bool isHard)
    {
        if (isHard)
        {
            MySceneManager.Instance.hardSet = true;
        }
        else
        {
            MySceneManager.Instance.hardSet = false;
        }
    }
    public void BkMenu()
    {
        MySceneManager.Instance.ChangeScene("MenuScene");
    }
}
