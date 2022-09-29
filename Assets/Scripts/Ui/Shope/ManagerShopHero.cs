using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManagerShopHero : Singleton<ManagerShopHero>
{
    [SerializeField] Button _comebackBtn;
    protected override void Awake()
    {
        base.Awake();
        _comebackBtn.onClick.AddListener(ComeBackHome);
    }
    public void ComeBackHome()
    {

    }


}
