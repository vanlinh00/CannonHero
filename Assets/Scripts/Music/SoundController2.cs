using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController2 : MonoBehaviour
{
    public static SoundController2 _instance;
    public AudioSource audioFx;
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this);
            return;
        }
        else
        {
            _instance = this;
        }
        //DontDestroyOnLoad(this);
    }
    private void OnValidate()
    {
        if (audioFx == null)
        {
            audioFx = gameObject.AddComponent<AudioSource>();
        }
    }
    public void OnPlayAudio(SoundType soundType)
    {
        var audio = Resources.Load<AudioClip>($"Audio/AudioClip/{soundType.ToString()}");
        audioFx.clip = audio;
        audioFx.Play();
        // audioFx.PlayOneShot(audio);

    }
    public void OfSound()
    {
        audioFx.volume = 0f;
    }
    public void OnSound()
    {
        audioFx.volume = 1f;
    }
}
