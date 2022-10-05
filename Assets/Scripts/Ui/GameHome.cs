using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHome : MonoBehaviour
{
    [SerializeField] Button _startGamePlayBtn;
    [SerializeField] Button _openShopBtn;
    [SerializeField] Button _musicBtn;
    [SerializeField] Button _soundBtn;

    [SerializeField] Animator _animator;
    private void Awake()
    {
        _startGamePlayBtn.onClick.AddListener(OpenGamePlay);
        _openShopBtn.onClick.AddListener(OpenShop);
    }
    public void OpenGamePlay()
    {
        AlwaysPresent._instance.SetActiveTutorial(false);
        UiController._instance.OpenGamePlay();
    }
    public void OpenShop()
    {
        GameController._instance.SetActiveRegionShop(true);
        GameController._instance.isOnShop = true;
        UiController._instance.OpenShop();
        CameraController._instance.GoToShop();
    }
    public void In()
    {
        _animator.SetBool("out", false);
    }
    public void Out()
    {
        _animator.SetBool("out", true);
    }
}
