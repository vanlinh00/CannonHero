using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ElementBtn : MonoBehaviour
{
    public int idHero;
    [SerializeField] int _priceHero;

    [SerializeField] GameObject _darkBg;
    [SerializeField] Button _clickHeroBtn;

    private void Awake()
    {
        _clickHeroBtn.onClick.AddListener(CheckHero);
    }
    private void OnEnable()
    {
        if(DataPlayer.GetInforPlayer().idHeroPlaying==idHero)
        {
            _darkBg.SetActive(false);
        }
    }
    public void CheckHero()
    {
        SoundController._instance.OnPlayAudio(SoundType.mouse_click);
        RegionShop._instance.LoadHero(idHero);
        ManagerShopHero._instance.ChangeButtonClick(_darkBg);
        ManagerShopHero._instance.CheckHeroOnShop(idHero,_priceHero);
    }
    public int GetPriceHero()
    {
        return _priceHero;
    }
}
