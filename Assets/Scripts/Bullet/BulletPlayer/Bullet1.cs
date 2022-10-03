using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : BulletPlayer,Iflyable
{
    [SerializeField] GameObject _exploteParticle;
    [SerializeField] int _idBullet;
    protected override void Start()
    {
        base.Start();
    }
    public void Fly()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        ObjectPooler._instance.SpawnFromPool("ExplodePartile", _exploteParticle.transform.position, Quaternion.identity);
        ObjectPooler._instance.AddElement("Bullet"+ _idBullet, gameObject);
        gameObject.SetActive(false);

        //gameObject.transform.GetChild(0).GetComponent<LineBullet3>().WaitTime();
    }
}
