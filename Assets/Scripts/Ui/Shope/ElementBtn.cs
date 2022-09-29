using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 44
//31
public class ElementBtn : MonoBehaviour
{   
    [SerializeField] GameObject _dackBg;
    public int idHero;
    [SerializeField] Button _clickHeroBtn;
    [SerializeField] Button _selectBtn;
    [SerializeField] Button _priceBtn;
    [SerializeField] int _priceHero;
    private void Awake()
    {
        _clickHeroBtn.onClick.AddListener(CheckHero);
        _selectBtn.onClick.AddListener(ComeBackHome);
        _priceBtn.onClick.AddListener(BuyHero);
    }
    public void CheckHero()
    {

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
