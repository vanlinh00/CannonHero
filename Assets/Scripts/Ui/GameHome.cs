using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHome : MonoBehaviour
{
    [SerializeField] Button _startGamePlayBtn;
    [SerializeField] Button _openShopBtn;
    [SerializeField] Button _musicBtn;
    [SerializeField] Button _soundBtn;
    [SerializeField] Animator _animator;
    [SerializeField] Text _bestScore;

     private void OnEnable()
    {
        StartCoroutine(WaitTimeLoadData());
    }
    IEnumerator WaitTimeLoadData()
    {
        yield return new WaitForEndOfFrame();
        _bestScore.text = "Best " + DataPlayer.GetInforPlayer().bestScore.ToString();
        ChangeMusic();
        ChangeSound();
    }
    private void Awake()
    {
        _startGamePlayBtn.onClick.AddListener(OpenGamePlay);
        _openShopBtn.onClick.AddListener(OpenShop);
        _musicBtn.onClick.AddListener(OnMusic);
        _soundBtn.onClick.AddListener(OnSound);
    }
    public void OpenGamePlay()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        AlwaysPresent._instance.SetActiveTutorial(false);
        UiController._instance.OpenGamePlay();
    }
    public void OpenShop()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        GameController._instance.SetActiveRegionShop(true);
        GameController._instance.isOnShop = true;
        UiController._instance.OpenShop();
        CameraController._instance.GoToShop();
    }

    public void In()
    {
        _animator.SetBool("out", false);
    }
    public void Out()
    {
        _animator.SetBool("out", true);
    }
    public void OnMusic()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        DataPlayer.ChangeStateAudio(!DataPlayer.GetInforPlayer().isOnMusicBg);
        ChangeMusic();
    }
    public void OnSound()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        DataPlayer.ChangeStateSound(!DataPlayer.GetInforPlayer().isOnSound);
        ChangeSound();
    }
    public void ChangeMusic()
    {
        if (DataPlayer.GetInforPlayer().isOnMusicBg)
        {
            SoundBackGround._instance.OnMusic();
            _musicBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Audio/MusicBg2");
        }
        else
        {
            SoundBackGround._instance.OfMusic();
            _musicBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Audio/MusicBg1");
        }
    }
    public void ChangeSound()
    {
        if (DataPlayer.GetInforPlayer().isOnSound)
        {
            SoundController._instance.OnSound();
            SoundController2._instance.OnSound();
            _soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Audio/Sound2");
        }
        else
        {
            SoundController._instance.OfSound();
            SoundController2._instance.OfSound();
            _soundBtn.GetComponent<Image>().sprite = Resources.Load<Sprite>("Audio/Sound1");
        }
    }
}
