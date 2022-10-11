using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBullet9 : BulletPlayer, Iflyable
{
    [SerializeField] float _angle;
    [SerializeField] int _idBullet;
    [SerializeField] GameObject _exploteParticle;
    public int idSmallBullet;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] GameObject _trail;
    [SerializeField] GameObject _paticle;
    [SerializeField] Rigidbody2D _rb;
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
        if (!collision.gameObject.CompareTag("SmallBullet9"))
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                if(_idBullet == 9)
                {
                    SetActiveObject(false);
                }
                gameObject.transform.parent.GetComponent<Bullet7>().DisableColisionAllBullet();
                StartCoroutine(WaitTimeRenew());
                ObjectPooler._instance.SpawnFromPool("ExplodeParticle" + _idBullet, _exploteParticle.transform.position, Quaternion.identity);
            }
            else
            {
                if(collision.gameObject.CompareTag("BodyPillar"))
                {
                    if (_idBullet == 9)
                    {
                        SetActiveObject(false);
                    }
                }
                if (!collision.gameObject.CompareTag("MissBullet"))
                {
                    ObjectPooler._instance.SpawnFromPool("ExplodeParticle" + _idBullet, _exploteParticle.transform.position, Quaternion.identity);
                }

                if (idSmallBullet == 3)
                {
                    GameController._instance.isGameOver = true;
                    gameObject.transform.parent.GetComponent<Bullet7>().Renew();
                }
            }
        }
    }
    IEnumerator WaitTimeRenew()
    {
        yield return new WaitForSeconds(0.8f);
        gameObject.transform.parent.GetComponent<Bullet7>().Renew();
    }
    public void SetActiveObject(bool res)
    {
        _spriteRenderer.enabled = res;
        _trail.SetActive(res);
        _paticle.SetActive(res);

    }


}
