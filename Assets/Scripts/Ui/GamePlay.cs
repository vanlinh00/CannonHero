using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : Singleton<GamePlay>
{
    [SerializeField] Button _pauseBtn;
    [SerializeField] Text _countScore;
    protected override void Awake()
    {
        base.Awake();
        _pauseBtn.onClick.AddListener(PauseGame);
    }
    public void PauseGame()
    {
       UiController._instance.OpenPauseGame();
       GameController._instance.isPause = true;
        Time.timeScale = 0;
    }
    public void CountScore()
    {
         GameController._instance.CountScore();
        _countScore.GetComponent<Score>().CountScore();
    }

}
