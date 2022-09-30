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
            GameController._instance.IsGameOver = true;
        }
    }
}
