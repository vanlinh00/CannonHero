using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    private List<GameObject> _listObectCoins;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        _listObectCoins = new List<GameObject>();
    }
    public List<GameObject> BonrCoins(int Number, Vector3 PosCoin)
    {
        Vector3 NewPos;
        for (int i = 0; i <= Number; i++)
        {
            NewPos = new Vector3(PosCoin.x + Random.RandomRange(-0.3f, 0.3f), PosCoin.y + Random.RandomRange(-0.3f, 0.3f), 0f);
            GameObject NewCoin = ObjectPooler._instance.SpawnFromPool("Coin", NewPos, Quaternion.identity);
            NewCoin.SetActive(false);
            NewCoin.SetActive(true);

            Coin CoinSc = NewCoin.GetComponent<Coin>();
            CoinSc.ResetCoin();
            CoinSc.StateIdle();
            CoinSc.AddForce();
            _listObectCoins.Add(NewCoin);
        }
        return _listObectCoins;
    }
    public void AddCoinsToPool()
    {
       foreach(GameObject coin in _listObectCoins)
        {
            ObjectPooler._instance.AddElement("Coin", coin);
            coin.transform.parent = ObjectPooler._instance.transform;
        }
        _listObectCoins.Clear();
    }
}
