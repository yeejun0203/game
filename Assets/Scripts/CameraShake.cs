using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraShake : MonoBehaviour
{
    CinemachineVirtualCamera virtualCamera;
    CinemachineBasicMultiChannelPerlin noisePerlin;

    private void Awake()
    {
        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        noisePerlin = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }
    public void ShakeCamera(float damage = 1, float shakeTime = 1)
    {
        StartCoroutine(StartShake(damage, shakeTime));
    }
    IEnumerator StartShake(float damage, float shakeTime)
    {
        noisePerlin.m_AmplitudeGain = damage;
        noisePerlin.m_FrequencyGain = damage;
        yield return new WaitForSeconds(shakeTime);
        noisePerlin.m_AmplitudeGain = 0;
        noisePerlin.m_FrequencyGain = 0;
    }
}

