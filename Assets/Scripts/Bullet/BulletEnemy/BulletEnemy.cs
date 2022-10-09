using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : BaseBullet, Iflyable
{
    Vector3 _posPlayer;

    public void FindPosPlayer()
    {
        _posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 _currentPos = transform.position;
        Vector3 _targetPos = _posPlayer;
        transform.Translate((_targetPos - _currentPos)*Time.deltaTime*bulletSpeed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
         {
            ObjectPooler._instance.AddElement("BulletEnemy", this.gameObject);
            gameObject.SetActive(false);
         }
     
    }

    public void Fly()
    {
       // throw new System.NotImplementedException();
    }
}
