using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : BaseBullet
{
    Vector3 _posPlayer;
    private void Start()
    {
        _posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    private void FixedUpdate()
    {
        Vector3 _currentPos = transform.position;
        Vector3 _targetPos = _posPlayer;
        transform.Translate((_targetPos - _currentPos)*Time.deltaTime*bulletSpeed);
    }
}
