using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : Singleton<UiController>
{
    [SerializeField] Button RestartBtn;
    [SerializeField] GameObject _gameHomePanel;
    [SerializeField] GameObject _pauseGamePanel;
    [SerializeField] GameObject _gamePlayPanel;
    [SerializeField] GameObject _gamOverPanel;
    [SerializeField] GameObject _shopPanel;
    protected override void Awake()
    {
        base.Awake();
        RestartBtn.onClick.AddListener(RestartGame);
    }
    private void Start()
    {
        OpenGameHome();
        StartCoroutine(WaitTimeEnableSound());
    }
    IEnumerator WaitTimeEnableSound()
    {
        yield return new WaitForEndOfFrame();
        SoundBackGround._instance.OnPlayAudio(SoundType.BackGround);
    }
    void RestartGame()
    {
         SceneManager.LoadScene(0);
    }
    public void OpenGamePlayAgain()
    {
        _gameHomePanel.SetActive(false);
        _shopPanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamOverPanel.SetActive(false);
        _gamePlayPanel.SetActive(true);
    }
    public void OpenGamePlay()
    {
        StartCoroutine(DisableGameHome());
        _shopPanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamOverPanel.SetActive(false);
        _gamePlayPanel.SetActive(true);
        _gamePlayPanel.GetComponent<GamePlay>().In();
    }
    IEnumerator DisableGameHome()
    {
        _gameHomePanel.GetComponent<GameHome>().Out();
        yield return new WaitForSeconds(0.50f);
        _gameHomePanel.SetActive(false);
    }
    public void OpenGameHome()
    {
        _shopPanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamOverPanel.SetActive(false);
        _gamePlayPanel.SetActive(false);
        _gameHomePanel.GetComponent<GameHome>().In();
        _gameHomePanel.SetActive(true);
    }
    
    public void OpenGameOver(bool IsComback)
    {
        _shopPanel.SetActive(false);
        _gameHomePanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamePlayPanel.SetActive(false);
        StartCoroutine(WaitEnableGameOver(IsComback));
    }
    IEnumerator WaitEnableGameOver(bool IsComback)
    {
        if(!IsComback)
        {
            yield return new WaitForSeconds(0.9f);

        }
        _gamOverPanel.SetActive(true);
    }
    public void OpenPauseGame()
    {
        _shopPanel.SetActive(false);
        _gamOverPanel.SetActive(false);
        _gameHomePanel.SetActive(false);
        _gamePlayPanel.SetActive(false);
        _pauseGamePanel.SetActive(true);
    }   
    public void OpenShop()
    {
        _gamOverPanel.SetActive(false);
        _gameHomePanel.SetActive(false);
        _gamePlayPanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _shopPanel.SetActive(true);

    }
   public IEnumerator FadeDisPlayGameOver()
    {
        yield return new WaitForSeconds(0.0001f);
        OpenGameOver(false);
    }
}
