using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet7 : BulletPlayer, Iflyable
{
    [SerializeField] GameObject[] _smallBullets;
    [SerializeField] int _idBullet;
    [SerializeField] float _timeWaitFly;
    protected override void Start()
    {
        base.Start();
    }
    private void FixedUpdate()
    {

    }
    public void Fly()
    {
        StartCoroutine(FadeFly());
    }
    public IEnumerator FadeFly()
    {
        for (int i = 0; i < _smallBullets.Length; i++)
        {
             _smallBullets[i].GetComponent<BulletPlayer>().bulletSpeed = base.bulletSpeed;
             _smallBullets[i].GetComponent<Iflyable>().Fly();
            yield return new WaitForSeconds(_timeWaitFly);
        }
    }
    public void DisableColisionAllBullet()
    {
        for (int i = 0; i < _smallBullets.Length; i++)
        {
            _smallBullets[i].GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    public void Renew()
    {
        for (int i = 0; i < _smallBullets.Length; i++)
        {
            _smallBullets[i].transform.localPosition = new Vector3(0, 0, 0);
            _smallBullets[i].GetComponent<BoxCollider2D>().enabled = true;
            _smallBullets[i].GetComponent<SpriteRenderer>().enabled = true;
            _smallBullets[i].transform.GetChild(0).gameObject.SetActive(true);
            _smallBullets[i].transform.GetChild(1).gameObject.SetActive(true);

        }
        ObjectPooler._instance.AddElement("BulletPlayer" + _idBullet, gameObject);
        gameObject.SetActive(false);
    }
}
