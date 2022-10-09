using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissBullet : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private bool _isMove=false;
    private void Start()
    {
        StartCoroutine(WaitTimeLoadPlayer());
    }
    IEnumerator WaitTimeLoadPlayer()
    {
        yield return new WaitForSeconds(1f);

        player = GameObject.FindGameObjectWithTag("Player");
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        _isMove = true;
    }
    private void Update()
    {
        if(_isMove)
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, -10); // 
        }
    }
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
        }

    }

}
