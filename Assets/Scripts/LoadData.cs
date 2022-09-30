using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] Vector3 _positionPlayer;
    private void OnEnable()
    {
    }
    private void Start()
    {
        WaitLoadDataWithHero(); 
    }
    void  WaitLoadDataWithHero()
    {
        int IdHero = DataPlayer.GetInforPlayer().idHeroPlaying;

        GameObject Player = Instantiate(Resources.Load("Hero/Hero" + IdHero, typeof(GameObject)), _positionPlayer, Quaternion.identity) as GameObject;

        GameController._instance.SetupGame(Player);

        GameObject bullet = Instantiate(Resources.Load("Bullet/Bullet" + 1, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        bullet.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "Bullet1", bullet);

        GameObject ExplodeParticle = Instantiate(Resources.Load("Particle/Skin"+1+"/ExplodeParticle", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        ExplodeParticle.SetActive(false);
        ObjectPooler._instance.CreateQueObject(2, "ExplodePartile", ExplodeParticle);


        //Load BackGround
        GameObject BulletEnemy = Instantiate(Resources.Load("Bullet/Bullet" + 0, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        BulletEnemy.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "Bullet" + 0, BulletEnemy);

        GameObject Pillar = Instantiate(Resources.Load("Pillar/Pillar", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Pillar.SetActive(false);
        ObjectPooler._instance.CreateQueObject(3, "Pillar", Pillar);

        GameObject Coin = Instantiate(Resources.Load("Coins/Coin", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Coin.SetActive(false);
        ObjectPooler._instance.CreateQueObject(12, "Coin", Coin);

    }
}
