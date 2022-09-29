using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ManagerShopHero : Singleton<ManagerShopHero>   
{
    [SerializeField] Button _comebackBtn;
    public GameObject _currentDarkClickBtn=null;
    public GameObject _nexDarkClickBtn=null;
    protected override void Awake()
    {
        base.Awake();
        _comebackBtn.onClick.AddListener(ComeBackHome);
    }
    public void ComeBackHome()
    {
        UiController._instance.OpenGameHome();
        CameraController._instance.GoToHome();
        GameController._instance.isOnShop = false;

        if(GameController._instance.Player().statePlayer==PlayerController.StatePlayer.Die)
        {
            UiController._instance.OpenGameOver();
        }
    }
    public void ChangeBackDarkBackGround()
    {

    }
    public void ChangeButtonClick(GameObject NextDarkBg)
    {  
        if(_currentDarkClickBtn!=null)
        {
            _currentDarkClickBtn.SetActive(true);
        }   
        _currentDarkClickBtn = NextDarkBg;
        _currentDarkClickBtn.SetActive(false);
        
    }

}
