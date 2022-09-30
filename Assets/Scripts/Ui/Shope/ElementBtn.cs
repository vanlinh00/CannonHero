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
    public void CheckHero()
    {
        RegionShop._instance.LoadHero(idHero);
        ManagerShopHero._instance.ChangeButtonClick(_darkBg);
        ManagerShopHero._instance.CheckHeroOnShop(idHero,_priceHero);
    }
}
