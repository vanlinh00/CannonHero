using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {    
            GameController._instance.isGameOver = true;
            collision.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            GameController._instance.isGameOver = true;

        }else if(collision.gameObject.CompareTag("SmallBullet9"))
        {
            if(collision.gameObject.GetComponent<SmallBullet9>().idSmallBullet==3)
            {
                GameController._instance.isGameOver = true;
            }
           }

    }

}
