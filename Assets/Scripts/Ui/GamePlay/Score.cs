using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] Text _scoreTxt;
    [SerializeField] Animator _animator;
    private void Start()
    {
        StateIdle();
    }
    public void StateIdle()
    {
        _animator.SetBool("vibrate", false);
    }
    public void StateVibrate()
    {
        _animator.SetBool("vibrate", true);
    }
    public void CountScore()
    {
        _scoreTxt.text = GameController._instance.GetCurrentScore().ToString();
     
        StateVibrate();
         StartCoroutine(WaitVibrate());
    }
    IEnumerator WaitVibrate()
    {
        yield return new WaitForSeconds(0.03f);
        StateIdle();

    }
}
