using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyEnemy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameObject.transform.parent.GetComponent<EnemyController>().Die();
        }
    }
}
