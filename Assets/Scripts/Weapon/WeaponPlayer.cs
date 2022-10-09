using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPlayer : Weapon
{
    public bool isFiver = false;
    //snatch gun
    [SerializeField] float _speedSnatch;
    [SerializeField] Vector3 _targetPos;
    [SerializeField] Vector3 _currentPos;

    [SerializeField] TrailRenderer _trailRenderer;
    [SerializeField] GameObject _support;
    [SerializeField] GameObject _ferverParticle;

    public void AutoRotate()
    {
        _target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentAngleZ);
        currentAngleZ = currentAngleZ + Time.deltaTime * _speedRotate;
        transform.rotation = _target;
    }
    IEnumerator Move(Transform CurrentTransform, Vector3 Target, float TotalTime)
    {
        var passed = 0f;
        var init = CurrentTransform.transform.position;
        while (passed < TotalTime)
        {
            passed += Time.deltaTime;
            var normalized = passed / TotalTime;
            var current = Vector3.Lerp(init, Target, normalized);
            CurrentTransform.position = current;
            yield return null;
        }
    }
    public void Shoot()
    {
        StartCoroutine(WaitShoot());
    }
    IEnumerator WaitShoot()
    {
        _particleFirePoint.SetActive(true);
        _bullet = ObjectPooler._instance.SpawnFromPool("BulletPlayer" + idBullet, PosFirePoint(), _target);

        BulletPlayer bulletPlayer = _bullet.GetComponent<BulletPlayer>();

        if (isFiver)
        {
            bulletPlayer.stateBullet = BulletPlayer.StateBullet.Fiver;
        }
        else
        {
            bulletPlayer.stateBullet = BulletPlayer.StateBullet.Normal;
        }

        bulletPlayer.SetUp();
        bulletPlayer.bulletSpeed = _bulletForce;
        bulletPlayer.GetComponent<Iflyable>().Fly();
        StartCoroutine(Snatch());
        yield return new WaitForSeconds(1f);
        _particleFirePoint.SetActive(false);
    }

    //Snatch gun
    IEnumerator Snatch()
    {
        _targetPos = new Vector3(transform.position.x - 0.14f, transform.position.y, 0);
        _currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        StartCoroutine(Move(transform, _targetPos, _speedSnatch));
        yield return new WaitForSeconds(_speedSnatch);
        StartCoroutine(Move(transform, _currentPos, _speedSnatch));
        yield return new WaitForSeconds(_speedSnatch);
    }
    public void ClearTrail()
    {
        _trailRenderer.Clear();
        _trailRenderer.gameObject.SetActive(false);
        _support.SetActive(false);
    }
    public void SetEnableTrail()
    {
        _trailRenderer.gameObject.SetActive(true);
        _support.SetActive(true);
    }
    public void SetActiveFeverParticle(bool res)
    {
        _ferverParticle.SetActive(res);
    }
}
