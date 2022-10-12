using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : Singleton<PauseGame>
{
    [SerializeField] Button _musicBtn;
    [SerializeField] Button _soundBtn;
    [SerializeField] Button _playBtn;
    [SerializeField] Button _homeBtn;
    [SerializeField] Button _restartBtn;
    protected override void Awake()
    {
        base.Awake();
        _playBtn.onClick.AddListener(PlayGame);
        _homeBtn.onClick.AddListener(GotoHome);
        _restartBtn.onClick.AddListener(RestartGame);
        _musicBtn.onClick.AddListener(OnMusic);
        _soundBtn.onClick.AddListener(OnSound);
    }
    private void OnEnable()
    {
        ChangeMusic();
        ChangeSound();
    }
    private void RestartGame()
    {
        //Time.timeScale = 1;

        //SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        //GameController._instance.LoadScenceAgain();
        //UiController._instance.OpenGamePlay();
        //GamePlay._instance.CountScore();

        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void GotoHome()
    {
        //    Time.timeScale = 1;
        //    SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        //    GameController._instance.LoadScenceAgain();
        //    UiController._instance.OpenGameHome();
        //    GamePlay._instance.CountScore();    

        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        Time.timeScale = 1;
        GameController._instance.isPause = false;
        UiController._instance.OpenGamePlay();
       // GameController._instance.Test();
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
