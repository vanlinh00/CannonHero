using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            GameController._instance.isGameOver = true;
            StartCoroutine(WaitTimeSetActive(collision.gameObject));
        }
    }
    IEnumerator WaitTimeSetActive(GameObject Bullet)
    {
        yield return new WaitForSeconds(0.05f);
        Bullet.gameObject.SetActive(false);
    }
}
