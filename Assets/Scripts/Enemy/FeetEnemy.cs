using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetEnemy : MonoBehaviour
{
    [SerializeField] GameObject _particleBoolFeetEnemy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            ColliderBullet();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("SmallBullet9"))
        {
            ColliderBullet();
        }

    }
    void ColliderBullet()
    {
        _particleBoolFeetEnemy.SetActive(true);
        gameObject.transform.parent.GetComponent<EnemyController>().isHitFeet = true;
        gameObject.transform.parent.GetComponent<EnemyController>().Die();
    }
    public void SetActiveParticleBoolFeetEnemy(bool res)
    {
        _particleBoolFeetEnemy.SetActive(res);
    }
}
