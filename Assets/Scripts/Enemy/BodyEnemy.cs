using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEnemy : MonoBehaviour
{
    [SerializeField] GameObject _particleBoolBodyEnemy;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _particleBoolBodyEnemy.SetActive(true);
            gameObject.transform.parent.GetComponent<EnemyController>().isHitBody = true;
            gameObject.transform.parent.GetComponent<EnemyController>().Die();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Bullet")|| collision.gameObject.CompareTag("SmallBullet9"))
        {
            _particleBoolBodyEnemy.SetActive(true);
            gameObject.transform.parent.GetComponent<EnemyController>().isHitBody = true;
            gameObject.transform.parent.GetComponent<EnemyController>().Die();
        }
    }
    public void SetActiveParticleBoolBody(bool res)
    {
        _particleBoolBodyEnemy.SetActive(res);
    }
}
