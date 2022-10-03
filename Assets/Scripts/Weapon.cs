using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] protected float _speedRotate = 1.5f;
    [SerializeField] protected GameObject _firePoint;
    [SerializeField] protected GameObject _particleFirePoint;
    public float currentAngleZ = 0f;
    protected Quaternion _target;

    // Bullet 
    [SerializeField] protected GameObject _bullet;
    [SerializeField] protected float _bulletForce;
    public float idBullet;

    public Vector3 PosFirePoint()
    {
        return _firePoint.transform.position; 
    }
   public void ResetRotation()
    {
        currentAngleZ = 0f;
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
