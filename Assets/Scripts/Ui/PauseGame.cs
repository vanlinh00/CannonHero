using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    [SerializeField] Button _soundBtn;
    [SerializeField] Button _musicBtn;
    [SerializeField] Button _playBtn;
    [SerializeField] Button _homeBtn;
    [SerializeField] Button _combackBtn;

    private void Awake()
    {
        _playBtn.onClick.AddListener(PlayGame);
    }
    public void PlayGame()
    {
        UiController._instance.OpenGamePlay();
        Time.timeScale = 1;
    }
}
