using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPillar : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            transform.parent.parent.GetComponent<Pillar>().StateShock();
            GameController._instance.isGameOver = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet") || collision.gameObject.CompareTag("SmallBullet9"))
          {
            transform.parent.parent.GetComponent<Pillar>().StateShock();
        }
    }
}
