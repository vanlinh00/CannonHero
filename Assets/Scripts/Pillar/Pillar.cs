using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] GameObject _enemy;
    [SerializeField] EnemyController _enemyController;
    [SerializeField] GameObject _bodyPillar;

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
     List<GameObject> ListCoins = CoinManager._instance.BonrCoins(8, PosCoin);
      foreach(GameObject Coin in ListCoins)
        {
            Coin.transform.parent = transform;
        }
    }
}
