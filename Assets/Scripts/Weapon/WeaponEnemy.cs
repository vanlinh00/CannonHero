using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponEnemy : Weapon
{
    public void Shoot()
    {
        StartCoroutine(WaitShoot());
    }
    IEnumerator WaitShoot()
    {
        _particleFirePoint.SetActive(true);
        _bullet = ObjectPooler._instance.SpawnFromPool("BulletEnemy", PosFirePoint(), _target);
        BulletEnemy bulletEnemy = _bullet.GetComponent<BulletEnemy>();
        bulletEnemy.bulletSpeed = _bulletForce;
        bulletEnemy.FindPosPlayer();
        yield return new WaitForSeconds(1f);
        _particleFirePoint.SetActive(false);
    }

    public IEnumerator FadeRotateToTarget(float currentDegree, float TargetDegree)
    {
        float t = currentDegree;
        while (t <= TargetDegree)
        {
            yield return new WaitForEndOfFrame();
            t += base._speedRotate * Time.deltaTime;
            Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, (t < TargetDegree) ? t : TargetDegree);
            transform.rotation = target;
        }
    }
}
