﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] EnemyController _enemyController;
    [SerializeField] GameObject _bodyPillar;
    [SerializeField] Animator _animator;

    //private void Start()
    //{
    //    _enemyController=_enemy.GetComponent<EnemyController>();
    //}
    public GameObject GetEnemy()
    {
        return _enemy;
    }
    public GameObject GetPillar()
    {
        return _bodyPillar;
    }
    public void ResetPillar()
    {
        StateIdle();
        _enemyController.isBornCoin = true;
        _enemyController.RemoveRigibody();
        _enemyController.ResetEnemy();
        _enemyController.GetWeapon().ResetRotation();
    }
    public void SetEnabledColliderInBody(bool Res)
    {
        _bodyPillar.GetComponent<PolygonCollider2D>().enabled = Res;
    }
    public void BonrNewCoinOnPillar(Vector3 PosCoin)
    {
     List<GameObject> ListCoins = ItemManager._instance.BonrCoins(GameController._instance.AmountCoin(), PosCoin);

      foreach(GameObject Coin in ListCoins)
        {
            Coin.transform.parent = transform;
        }
    }
    public void BornDiamond(Vector3 PosDiamond)
    {
        List<GameObject> ListDiamond = ItemManager._instance.BornDiamonds(4, PosDiamond);

        foreach (GameObject Diamond in ListDiamond)
        {
            Diamond.transform.parent = transform;
        }
    }
    public void StateShock()
    {
        _animator.SetBool("Shock", true);
    }
    public void StateIdle()
    {
        _animator.SetBool("Shock", false);
    }
}
