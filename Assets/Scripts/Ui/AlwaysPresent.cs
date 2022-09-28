using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlwaysPresent : Singleton<AlwaysPresent>
{
    [SerializeField] Text _countCoins;
    [SerializeField] GameObject _tutorialTxt;

    protected override void Awake()
    {
        base.Awake();
    }
    public void SetActiveTutorial(bool res)
    {
        _tutorialTxt.SetActive(res);
    }
    public void CountCoins()
    {
        GameController._instance.CountCoins();
        _countCoins.text = GameController._instance.GetAmountCoins().ToString();

    }
}
