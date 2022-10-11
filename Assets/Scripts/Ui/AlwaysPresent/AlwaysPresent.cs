using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlwaysPresent : Singleton<AlwaysPresent>
{
    [SerializeField] GameObject _tutorialObj;
    [SerializeField] GameObject _notification;
    [SerializeField] GameObject _notificationFiver;
    [SerializeField] CoinOfPlayer _coinOfPlayer;
    protected override void Awake()
    {
        base.Awake();
    }

    public void SetActiveTutorial(bool res)
    {
        _tutorialObj.SetActive(res);
    }
    public CoinOfPlayer CoinOfplayer()
    {
        return _coinOfPlayer;
    }
    public void CountCoins()
    {
        _coinOfPlayer.CountCoins();
    }
    public void DisplayNoti(string NotiTxt)
    {
        _notification.GetComponent<Notification>().notificationTxt.text = NotiTxt.ToString();
        _notification.gameObject.SetActive(true);

    }
    public void DisplayNotiFeVer(string NotiTxt)
    {
        _notificationFiver.GetComponent<Notification>().notificationTxt.GetComponent<Text>().color = new Color32(255, 0, 0, 255);
        _notificationFiver.GetComponent<Notification>().notificationTxt.text = NotiTxt.ToString();
        _notificationFiver.gameObject.SetActive(true);

    }
}
