using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEnemy : MonoBehaviour
{
    [SerializeField] GameObject _particleBoolHead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            _particleBoolHead.SetActive(true);
            gameObject.transform.parent.GetComponent<EnemyController>().isHitHead = true;
            gameObject.transform.parent.GetComponent<EnemyController>().Die();
            gameObject.SetActive(false);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("SmallBullet9"))
        {
            _particleBoolHead.SetActive(true);
            gameObject.transform.parent.GetComponent<EnemyController>().isHitHead = true;
            gameObject.transform.parent.GetComponent<EnemyController>().Die();
            gameObject.SetActive(false);

        }
    }
    public void SetActiveParticleBoolHead(bool Res)
    {
        _particleBoolHead.SetActive(Res);
    }
}
