using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadData : MonoBehaviour
{
    private void OnEnable()
    {
       StartCoroutine(WaitLoadDataWithHero());
    }
   IEnumerator  WaitLoadDataWithHero()
    {
        yield return new WaitForEndOfFrame();
        int IdHero = 1; /*DataPlayer.GetInforPlayer().idHeroPlaying;*/

        GameObject bullet = Instantiate(Resources.Load("Bullet/Bullet" + IdHero, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        bullet.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "Bullet" + IdHero, bullet);

        GameObject BulletEnemy = Instantiate(Resources.Load("Bullet/Bullet" + 0, typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        BulletEnemy.SetActive(false);
        ObjectPooler._instance.CreateQueObject(1, "Bullet" + 0, BulletEnemy);

        GameObject Pillar = Instantiate(Resources.Load("Pillar/Pillar", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Pillar.SetActive(false);
        ObjectPooler._instance.CreateQueObject(3, "Pillar", Pillar);

        GameObject Coin = Instantiate(Resources.Load("Coins/Coin", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        Coin.SetActive(false);
        ObjectPooler._instance.CreateQueObject(12, "Coin", Coin);

        GameObject ExplodeParticle = Instantiate(Resources.Load("Particle/Skin" + IdHero+ "/ExplodeParticle", typeof(GameObject)), transform.position, Quaternion.identity) as GameObject;
        ExplodeParticle.SetActive(false);
        ObjectPooler._instance.CreateQueObject(2, "ExplodePartile", ExplodeParticle);
    }
}
