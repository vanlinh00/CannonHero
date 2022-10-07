using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : Singleton<LoadData>
{
    [SerializeField] Vector3 _positionPlayer;
    private void Start()
    {
        GameObject Player= LoadDataPlayer();
        GameController._instance.SetupPlayer(Player);
        CameraController._instance.SetUp(Player);
        GameController._instance.LoadDataGame();
        LoadDateEnemy();

    }
    protected override void Awake()
    {
        base.Awake();
    }
    public GameObject LoadDataPlayer()
    {
        int IdHero = DataPlayer.GetInforPlayer().idHeroPlaying;
        GameObject Player = ObjectPooler._instance.SpawnFromPool("Hero" + IdHero, _positionPlayer, Quaternion.identity);
        Player.transform.SetParent(null);
        return Player;
    }
    public void LoadDateEnemy()
    {
        GameController._instance.SetUpEnemy();
    }
    public void LoadDiaamonds()
    {
        for(int i=1;i<=4;i++ )
        {
            GameObject Diamond = Instantiate(Resources.Load("Diamond/gem0"+i, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
            Diamond.SetActive(false);
            ObjectPooler._instance.CreateQueObject(2, "Diamond0" + i, Diamond);
        }

    }
}
