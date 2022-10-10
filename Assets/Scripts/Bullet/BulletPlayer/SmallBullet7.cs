using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet7 : BulletPlayer,Iflyable
{
   [SerializeField]  float _angle;
   [SerializeField] int _idBullet;
   [SerializeField] GameObject _exploteParticle;

    public void Fly()
    {
        Rotation();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }
    public void Rotation()
    {
        transform.localRotation = Quaternion.Euler(0, 0, _angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(!collision.gameObject.CompareTag("Bullet"))
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                gameObject.transform.parent.GetComponent<Bullet7>().DisableColisionAllBullet();
                StartCoroutine(WaitTimeRenew());
                ObjectPooler._instance.SpawnFromPool("ExplodeParticle" + _idBullet, _exploteParticle.transform.position, Quaternion.identity);
            }
            else if(collision.gameObject.CompareTag("MissBullet"))
            {
                gameObject.transform.parent.GetComponent<Bullet7>().Renew();
            }
            else
            {
                ObjectPooler._instance.SpawnFromPool("ExplodeParticle" + _idBullet, _exploteParticle.transform.position, Quaternion.identity);
            }
        }
    }
    IEnumerator WaitTimeRenew()
    {
        yield return new WaitForSeconds(0.15f);
        gameObject.transform.parent.GetComponent<Bullet7>().Renew();
    }
}
