using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin noisePerlin;
    [SerializeField]
    private bool noShake;
    private void Awake()
    {
        instance = this;
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noisePerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void ShakeCamera(float damage = 1, float shakeTime = 1)
    {
        if (noShake == true) return;
        Coroutine cameraShakeCoru = StartCoroutine(StartShake(damage));
        StartCoroutine(StopShake(cameraShakeCoru, shakeTime));
    }
    IEnumerator StartShake(float damage)
    {
        while (true)
        {
            noisePerlin.m_AmplitudeGain = damage;
            noisePerlin.m_FrequencyGain = damage;
            yield return null;
        }
    }
    IEnumerator StopShake(Coroutine coru, float shakeTime)
    {
        yield return new WaitForSeconds(shakeTime);
        StopCoroutine(coru);
        noisePerlin.m_AmplitudeGain = 0;
        noisePerlin.m_FrequencyGain = 0;
        yield break;
    }
}

