using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 현재 스코어에 따라서 플레이어 이동속도의 값을 조절하는 함수
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
        if (GameManager.instance.gameScore < 300)/*올라가는 점수에따라 V_Val 값을 정함 300까진 playerlogic의 이동속도에 0.7곱해서 느리게*/
        {
            V_Val = 0.7f;
        }
        else if (GameManager.instance.gameScore < 900)//900점부턴0.9곱해서 조금느리게
        {
            V_Val = 0.9f;
        }
        else if (GameManager.instance.gameScore < 1500)//까진 원래속도
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
        else if (GameManager.instance.gameScore < 10000)//2배의 속도
        {
            V_Val = 2f;
        }
        else
        {
            V_Val =  1f;
        }
    }
}
