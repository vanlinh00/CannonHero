using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ManagerShopHero : Singleton<ManagerShopHero>   
{
    [SerializeField] Button _comebackBtn;
    [SerializeField] GameObject _currentDarkClickBtn;
    public GameObject _nexDarkClickBtn=null;
    [SerializeField] Button _priceBtn;
    [SerializeField] Button _selectBtn;

    public int idHeroSelect;
    private int _priceHeroSelect;

   [SerializeField] ScrollRect _scrollRect;
    [SerializeField] GameObject _content;
    protected override void Awake()
    {
        base.Awake();
        _comebackBtn.onClick.AddListener(ComeBackHome);
        _priceBtn.onClick.AddListener(CheckBuyHero);
       _selectBtn.onClick.AddListener(LoadGameWithHeroSelect);
    }

    private void OnEnable()
    {
        _currentDarkClickBtn = _content.transform.GetChild(DataPlayer.GetInforPlayer().idHeroPlaying - 1).GetChild(1).gameObject;
        SetAllDisableDarkBg();
         idHeroSelect = DataPlayer.GetInforPlayer().idHeroPlaying;
        _priceHeroSelect = _content.transform.GetChild(DataPlayer.GetInforPlayer().idHeroPlaying - 1).gameObject.GetComponent<ElementBtn>().GetPriceHero();
        CheckHeroOnShop(idHeroSelect, _priceHeroSelect);;
        AutoScroll();
    }
    public void SetAllDisableDarkBg()
    {
        int children = _content.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
            if(i != DataPlayer.GetInforPlayer().idHeroPlaying-1)
            {
                _content.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(true);
            }
            else
            {
                _content.transform.GetChild(i).gameObject.transform.GetChild(1).gameObject.SetActive(false);
            }
          
        }
    }
    public void ComeBackHome()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        GameController._instance.SetActiveRegionShop(false);

        idHeroSelect = DataPlayer.GetInforPlayer().idHeroPlaying;
        UiController._instance.OpenGameHome();
        CameraController._instance.GoToHome();
        GameController._instance.isOnShop = false;

        if(GameController._instance.Player().statePlayer==PlayerController.StatePlayer.Die)
        {
            UiController._instance.OpenGameOver(true);
        }
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
    private void CheckBuyHero()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        int AmountCoins = DataPlayer.GetInforPlayer().countCoins;

        if(AmountCoins>=_priceHeroSelect)
        {
            DataPlayer.UpdateAmountCoins(DataPlayer.GetInforPlayer().countCoins - _priceHeroSelect);
            AlwaysPresent._instance.CoinOfplayer().DisPlayAmountCoins();
            DataPlayer.AddNewIdHero(idHeroSelect);
            CheckHeroOnShop(idHeroSelect, _priceHeroSelect);
        }
    }
    public void CheckHeroOnShop(int IdHero,int PriceHero)
    {
        idHeroSelect = IdHero;
        _priceHeroSelect = PriceHero;

        if (IsBoughtThisHero(IdHero))
        {
            _priceBtn.gameObject.SetActive(false);
            _selectBtn.gameObject.SetActive(true);
        }
        else
        {
            _priceBtn.transform.GetChild(0).GetComponent<Text>().text = PriceHero.ToString();
            _priceBtn.gameObject.SetActive(true);
            _selectBtn.gameObject.SetActive(false);
        }
    }
    public bool IsBoughtThisHero(int IdHero)
    {
      return  DataPlayer.GetInforPlayer().listIdHero.Contains(IdHero);
    }
    public void LoadGameWithHeroSelect()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        DataPlayer.UpdateHeroPlaying(idHeroSelect);
        //DisableCurrentHero();
        //GameController._instance.isOnShop = false;
        //UiController._instance.OpenGameHome();
        //GameController._instance.LoadScenceAgain();
        //LoadData._instance.LoadDataPlayer();
        SceneManager.LoadScene(0);
    }

    void AutoScroll()
    {
        float PosScrool = DataPlayer.GetInforPlayer().idHeroPlaying / (float)10;
        _scrollRect.horizontalNormalizedPosition = PosScrool;
    }
}
