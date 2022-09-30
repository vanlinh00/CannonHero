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


    protected override void Awake()
    {
        base.Awake();
        _comebackBtn.onClick.AddListener(ComeBackHome);
        _priceBtn.onClick.AddListener(CheckBuyHero);
       _selectBtn.onClick.AddListener(LoadGameWithHeroSelect);
    }
    private void Start()
    {
        idHeroSelect = 1;
        _priceHeroSelect = 000;
        CheckHeroOnShop(idHeroSelect, _priceHeroSelect);
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
        int AmountCoins = DataPlayer.GetInforPlayer().countCoins;

        if(AmountCoins>=_priceHeroSelect)
        {
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
        DataPlayer.UpdateHeroPlaying(idHeroSelect);
        SceneManager.LoadScene(0);
    }
   
}
