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
    private void Awake()
    {
        _comebackHomeBtn.onClick.AddListener(ComeBackHome);
         _shopeBtn.onClick.AddListener(OpenShope);
        _replayBtn.onClick.AddListener(ReplayGame);
        //_shareBtn.onClick.AddListener(ComeBackHomeBtn);
        //_reviewBtn.onClick.AddListener(ComeBackHomeBtn);
    }

    void SetCurrentScore()
    {

    }
    void SetBestScore()
    {

    }
    public void ComeBackHome()
    {
        SceneManager.LoadScene(0);
    }
    public void OpenShope()
    {
        GameController._instance.isOnShop = true;
        UiController._instance.OpenShop();
        CameraController._instance.GoToShop();
    }
    public void ReplayGame()
    {
        SceneManager.LoadScene(0);
    }
}
