using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinOfPlayer : MonoBehaviour
{
    [SerializeField] Text _coinsTxt;
    [SerializeField] Animator _animator;
    [SerializeField] GameObject TextPLlus1;

    private void Start()
    {
        DisPlayAmountCoins();
    }
    public void DisPlayAmountCoins()
    {
        _coinsTxt.text = DataPlayer.GetInforPlayer().countCoins.ToString();
        StateIdle();
    }
    public void StateIdle()
    {
        _animator.SetBool("addCoins", false);
    }
    public void StateAddCoins()
    {
        _animator.SetBool("addCoins", true);
    }
    public void CountCoins()
    {
         GameController._instance.CountCoins();
        _coinsTxt.text = GameController._instance.GetCurrentCoins().ToString();  
        StateAddCoins();
        StartCoroutine(WaitAddCoins());
        TextPLlus1.SetActive(true);
    }
    IEnumerator WaitAddCoins()
    {
        yield return new WaitForSeconds(0.05f);
        TextPLlus1.SetActive(false);
        yield return new WaitForSeconds(0.1f);
        StateIdle();
    }
}

