using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] Text _currentScoreTxt;
    [SerializeField] Text _bestScoreTxt;

    [SerializeField] Button _comebackHomeBtn;
    [SerializeField] Button _shopeBtn;
    [SerializeField] Button _replayBtn;
    [SerializeField] Button _shareBtn;
    [SerializeField] Button _reviewBtn;

    [SerializeField] Button _resurrect;
    private void Awake()
    {
        _comebackHomeBtn.onClick.AddListener(ComeBackHome);
         _shopeBtn.onClick.AddListener(OpenShop);
        _replayBtn.onClick.AddListener(ReplayGame);
        //_shareBtn.onClick.AddListener(ComeBackHomeBtn);
        //_reviewBtn.onClick.AddListener(ComeBackHomeBtn);
        _resurrect.onClick.AddListener(ResurrectPlayer);
    }

    public void ResurrectPlayer()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        GameController._instance.ResurrectPlayer();
        UiController._instance.OpenGamePlay();
    }
    private void OnEnable()
    {
        UpdateCurrentScore();
    }
    public void UpdateCurrentScore()
    {
        int CurrentScore = GameController._instance.GetCurrentScore();
        _currentScoreTxt.text = CurrentScore.ToString();
        UpdateBestScore(CurrentScore);
    }
    public void UpdateBestScore(int CurrentScore)
    {
        int BestScore = DataPlayer.GetInforPlayer().bestScore;
        if (BestScore < CurrentScore)
        {
            BestScore = CurrentScore;
            DataPlayer.UpdateBestScore(BestScore);
        }
        _bestScoreTxt.text = "BEST "+ BestScore.ToString();
    }

    public void ComeBackHome()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        SceneManager.LoadScene(0);
    }
    public void OpenShop()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        GameController._instance.SetActiveRegionShop(true);
        GameController._instance.isOnShop = true;
        UiController._instance.OpenShop();
        CameraController._instance.GoToShop();
    }
    public void ReplayGame()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        DataPlayer.UpdataLoadGameAgain(true);
        SceneManager.LoadScene(0);
    }
}
