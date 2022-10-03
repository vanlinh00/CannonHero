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
    [SerializeField] GameObject _allwaysPresentPanel;
    [SerializeField] GameObject _shopPanel;
    protected override void Awake()
    {
        base.Awake();
        RestartBtn.onClick.AddListener(RestartGame);
    }
    //private void OnEnable()
    //{
    //    // Get data form DataPlayer
    //    InforPlayer inforPlayer = DataPlayer.GetInforPlayer();

    //    if (inforPlayer.isLoadGameAgain)
    //    {

    //    }
    //    else
    //    {
      
    //    }
    //}
    void RestartGame()
    {
         SceneManager.LoadScene(0);
       //  GameController._instance.LoadScenceAgain();
    }

    public void OpenGamePlay()
    {
        _gameHomePanel.SetActive(false);
        _shopPanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamOverPanel.SetActive(false);
        _gamePlayPanel.SetActive(true);
    }
    public void OpenGameHome()
    {
        _shopPanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamOverPanel.SetActive(false);
        _gamePlayPanel.SetActive(false);
        _gameHomePanel.SetActive(true);
    }
    public void OpenGameOver()
    {
        _shopPanel.SetActive(false);
        _gameHomePanel.SetActive(false);
        _pauseGamePanel.SetActive(false);
        _gamePlayPanel.SetActive(false);
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
        OpenGameOver();
    }
    //public GameObject GetAllwaysPresent()
    //{
    //    return _allwaysPresentPanel;
    //}
}
