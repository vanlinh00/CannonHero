using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] float _speedRotate = 1.5f;
    [SerializeField] GameObject _firePoint;
    public float currentAngleZ = 0f;
    private Quaternion _target;

    // Bullet 
    [SerializeField] GameObject _bullet;
    [SerializeField] float bulletForce;
    public float idBullet;
    public float lifeTimeBullet;
   
    public void AutoRotate()
    {
        _target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentAngleZ);
        currentAngleZ = currentAngleZ + Time.deltaTime * _speedRotate;
        transform.rotation = _target;
    }
    public void Shoot()
    {
        _bullet = ObjectPooler._instance.SpawnFromPool("Bullet" + idBullet, FirePoint(), _target);
        BaseBullet baseBullet = _bullet.GetComponent<BaseBullet>();
        baseBullet.bulletSpeed = bulletForce;
    }
    public Vector3 FirePoint()
    {
        return _firePoint.transform.position;
    }

   public IEnumerator FadeRotateToTarget(float currentDegree, float TargetDegree)
    {
        float t = currentDegree;
        while (t <= TargetDegree)
        {
            yield return new WaitForEndOfFrame();
            t += _speedRotate*Time.deltaTime;
            Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (t < TargetDegree) ? t : TargetDegree);
            transform.rotation = target;
        }
    }
}
