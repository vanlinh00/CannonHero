using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

// 44
//31
public class ElementBtn : MonoBehaviour
{
    public int idHero;
    [SerializeField] int _priceHero;

    [SerializeField] GameObject _darkBg;
    [SerializeField] Button _clickHeroBtn;
    [SerializeField] Button _selectBtn;
    [SerializeField] Button _priceBtn;
    private void Awake()
    {
        _clickHeroBtn.onClick.AddListener(CheckHero);
        //_selectBtn.onClick.AddListener(ComeBackHome);
        //_priceBtn.onClick.AddListener(BuyHero);
    }
    public void CheckHero()
    {
        ManagerShopHero._instance.ChangeButtonClick(_darkBg);
     //   Vector3 PosHero = new Vector3(44, 35, 0);
     //  ObjectPooler._instance.SpawnFromPool("HeroShop"+idHero, PosHero,Quaternion.identity);
    }

    public void ComeBackHome()
    {
      
    }
    public void BuyHero()
    {

    }
    public void SetPrice()
    {
        _priceBtn.transform.GetChild(0).GetComponent<Text>().text = _priceHero.ToString();
    }
    

}
