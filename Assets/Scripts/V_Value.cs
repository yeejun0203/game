using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// ���� ���ھ ���� �÷��̾� �̵��ӵ��� ���� �����ϴ� �Լ�
/// </summary>
public class V_Value : MonoBehaviour
{
    public static V_Value instance;
    public float V_Val;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        V_Val = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.gameScore < 300)/*�ö󰡴� ���������� V_Val ���� ���� 300���� playerlogic�� �̵��ӵ��� 0.7���ؼ� ������*/
        {
            V_Val = 0.7f;
        }
        else if (GameManager.instance.gameScore < 900)//900������0.9���ؼ� ���ݴ�����
        {
            V_Val = 0.9f;
        }
        else if (GameManager.instance.gameScore < 1500)//���� �����ӵ�
        {
            V_Val = 1f;
        }
        else if (GameManager.instance.gameScore < 2100)//~~
        {
            V_Val = 1.2f;
        }
        else if (GameManager.instance.gameScore < 3000)//~
        {
            V_Val = 1.4f;
        }
        else if (GameManager.instance.gameScore < 5000)//~
        {
            V_Val = 1.6f;
        }
        else if (GameManager.instance.gameScore < 8000)//~
        {
            V_Val = 1.8f;
        }
        else if (GameManager.instance.gameScore < 10000)//2���� �ӵ�
        {
            V_Val = 2f;
        }
        else
        {
            V_Val =  1f;
        }
    }
}
