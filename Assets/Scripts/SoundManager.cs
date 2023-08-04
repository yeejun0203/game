using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SOUNDS { Sweep }
public class SoundManager : MonoBehaviour
{

    [SerializeField] private List<SoundSource> sweepSources;

    [SerializeField] private List<AudioSource> sweepAudioSources;

    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }
    private static SoundManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this.gameObject);
            return;
        }
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        foreach (SoundSource source in sweepSources)
        {
            AudioSource _audio = gameObject.AddComponent<AudioSource>();
            _audio.clip = source.audioClip;
            _audio.volume = 0.2f;
            sweepAudioSources.Add(_audio);
        }
    }
    public void StartSoundEffect(SOUNDS audioName)
    {
        if (audioName == SOUNDS.Sweep)
        {
            foreach (AudioSource source in sweepAudioSources)
            {
                if(source.isPlaying)
                {
                    continue;
                } 
                else
                {
                    source.Play();
                    break;
                }
            }
        }
    }
}

[System.Serializable]
public class SoundSource
{
    public SOUNDS audioName;
    public AudioClip audioClip;
}
