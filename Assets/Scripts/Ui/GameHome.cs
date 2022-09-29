﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHome : MonoBehaviour
{
    [SerializeField] Button _startGamePlayBtn;
    [SerializeField] Button _openShopBtn;
    [SerializeField] Button _musicBtn;
    [SerializeField] Button _soundBtn;
    private void Awake()
    {
        _startGamePlayBtn.onClick.AddListener(OpenGamePlay);
    }
    public void OpenGamePlay()
    {
        AlwaysPresent._instance.SetActiveTutorial(false);
        UiController._instance.OpenGamePlay();
    }
}
