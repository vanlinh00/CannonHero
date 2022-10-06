using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    [SerializeField] Vector3 _positionPlayer;
    private void Start()
    {
        LoadDataGame(); 
    }
    void  LoadDataGame()
    {
        int IdHero = DataPlayer.GetInforPlayer().idHeroPlaying;
        GameObject Player = Instantiate(Resources.Load("Hero/Hero" + IdHero, typeof(GameObject)), _positionPlayer, Quaternion.identity) as GameObject;
        GameObject bullet = Instantiate(Resources.Load("Bullet/Bullet" + IdHero, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        bullet.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "Bullet"+ IdHero, bullet);
        GameObject ExplodeParticle = Instantiate(Resources.Load("Particle/Skin"+IdHero+"/ExplodeParticle", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        ExplodeParticle.SetActive(false);
        ObjectPooler._instance.CreateQueObject(2, "ExplodePartile", ExplodeParticle);

        LoadBulletEnemy();
        LoadBackGround();
        LoadDiaamonds();
        LoadCoin();

        GameController._instance.LoadDataGame();
        GameController._instance.SetupGame(Player);
 
    }
    public void LoadBackGround()
    {
        int idBg = Random.RandomRange(1,4);
        GameObject Pillar = Instantiate(Resources.Load("BackGround/Bg" + idBg+"/Pillar", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Pillar.SetActive(false);
        ObjectPooler._instance.CreateQueObject(3, "Pillar", Pillar);

        GameObject BgStatic1 = Instantiate(Resources.Load("BackGround/Bg" + idBg + "/BgStatic1", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        BgStatic1.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "BgStatic1", BgStatic1);

        GameObject BgStatic2 = Instantiate(Resources.Load("BackGround/Bg" + idBg + "/BgStatic2", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        BgStatic2.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "BgStatic2", BgStatic2);

        GameObject BgDynamic = Instantiate(Resources.Load("BackGround/Bg" + idBg + "/BgDynamic", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        BgDynamic.SetActive(false);
        ObjectPooler._instance.CreateQueObject(4, "BgDynamic", BgDynamic);

        GameObject Cloud = Instantiate(Resources.Load("BackGround/Bg" + idBg + "/Cloud", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Cloud.SetActive(false);
        ObjectPooler._instance.CreateQueObject(3, "Cloud", Cloud);

        GameObject Wall = Instantiate(Resources.Load("BackGround/Bg" + idBg + "/Wall", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Wall.SetActive(false);
        ObjectPooler._instance.CreateQueObject(4, "Wall", Wall);
    }
    public void LoadBulletEnemy()
    {
        GameObject BulletEnemy = Instantiate(Resources.Load("Bullet/Bullet" + 0, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        BulletEnemy.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "Bullet" + 0, BulletEnemy);
    }
    public void LoadCoin()
    {
        GameObject Coin = Instantiate(Resources.Load("Coins/Coin", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Coin.SetActive(false);
        ObjectPooler._instance.CreateQueObject(12, "Coin", Coin);
        GameObject BackGroundStatic = Instantiate(Resources.Load("Coins/Coin", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
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
