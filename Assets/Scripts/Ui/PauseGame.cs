﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] Button _soundBtn;
    [SerializeField] Button _musicBtn;
    [SerializeField] Button _playBtn;
    [SerializeField] Button _homeBtn;
    [SerializeField] Button _restartBtn;

    private void Awake()
    {
        _playBtn.onClick.AddListener(PlayGame);
        _homeBtn.onClick.AddListener(GotoHome);
        _restartBtn.onClick.AddListener(RestartGame);
    }
    private void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void GotoHome()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void PlayGame()
    {
        UiController._instance.OpenGamePlay();
        Time.timeScale = 1;
    }
  
}
