using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {    
            // this code is bug
            GameController._instance.IsGameOver = true;
            collision.gameObject.SetActive(false);
        }
    }
}
