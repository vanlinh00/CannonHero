using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadEnemy : MonoBehaviour
{
    public GameObject ParticleBoolHead;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            ParticleBoolHead.SetActive(true);
            gameObject.transform.parent.GetComponent<EnemyController>().isHitHead = true;
            gameObject.transform.parent.GetComponent<EnemyController>().Die();

        }
    }
}
