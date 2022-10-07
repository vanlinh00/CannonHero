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
        if(!collision.transform.CompareTag("MissBullet"))
        {
            ObjectPooler._instance.SpawnFromPool("ExplodeParticle" + _idBullet, _exploteParticle.transform.position, Quaternion.identity);
        }
        ObjectPooler._instance.AddElement("BulletPlayer" + _idBullet, gameObject);
        gameObject.SetActive(false);
    }
}
