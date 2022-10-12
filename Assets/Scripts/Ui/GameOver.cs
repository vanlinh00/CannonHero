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
    [SerializeField] Animator _animator;
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
        StartCoroutine(WaitTimeAniResurrectPlayer());
    }
    IEnumerator WaitTimeAniResurrectPlayer()
    {
        StateOut();
        yield return new WaitForSeconds(0.3f);
        GameController._instance.ResurrectPlayer();
    }
    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
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
        StartCoroutine(WaitTimeAniHome());
    }
    IEnumerator WaitTimeAniHome()
    {
        StateOut();
        yield return new WaitForSeconds(0.3f);
        GameController._instance.LoadScenceAgain();
        UiController._instance.OpenGameHome();
        
       // GamePlay._instance.CountScore();
    }
    public void OpenShop()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        StartCoroutine(WaitTimeAniOpenShop());
    }
    IEnumerator WaitTimeAniOpenShop()
    {
        StateOut();
        yield return new WaitForSeconds(0.3f);
        GameController._instance.SetActiveRegionShop(true);
        GameController._instance.isOnShop = true;
        UiController._instance.OpenShop();
        CameraController._instance.GoToShop();
    }

    public void ReplayGame()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);

        StartCoroutine(WaitTimeAniReplayGame());
    }
    IEnumerator WaitTimeAniReplayGame()
    {
        StateOut();
        yield return new WaitForSeconds(0.3f);
        GameController._instance.LoadScenceAgain();
        UiController._instance.OpenGamePlay();
    }
    public void StateIn()
    {
        _animator.SetBool("In", true);
    }
    public void StateOut()
    {
        _animator.SetBool("In", false);
    }
}
