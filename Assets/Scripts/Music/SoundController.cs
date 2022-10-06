using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    BackGround = 0,
    Coin=1,
    mouse_click = 2,
    Victory =3,
    cannon_fire = 4,
    rifle_cock = 5,
    Die = 6,
    PassPillar=7,
}
public class SoundController : MonoBehaviour
{
    public static SoundController _instance;
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
       // audioFx.Play();
        audioFx.PlayOneShot(audio);

    }
}