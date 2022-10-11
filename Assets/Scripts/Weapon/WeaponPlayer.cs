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
    [SerializeField] GameObject _bigFever;
    [SerializeField] GameObject _smallFever;
   
    public void AutoRotate()
    {
        _target = Quaternion.Euler(transform.rotation.x, transform.rotation.y, currentAngleZ);
        currentAngleZ = currentAngleZ + Time.deltaTime * _speedRotate;
        transform.rotation = _target;

        if (_bigFever.activeSelf)
        {
            _bigFever.transform.localRotation = Quaternion.Euler(0, 0, -currentAngleZ);
        }
        if (_smallFever.activeSelf)
        {
            _smallFever.transform.localRotation = Quaternion.Euler(0, 0, -currentAngleZ);
        }
    }
    public void ResetRotationFever()
    {
        if (_bigFever.activeSelf)
        {
            _bigFever.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (_smallFever.activeSelf)
        {
            _smallFever.transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
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
        _currentPos = new Vector3(transform.position.x, transform.position.y, 0);
        int NumberShot = (base.idBullet == 9|| base.idBullet == 10) ? 3 : 1;

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

        for (int i=0;i< NumberShot; i++)
        {
            _particleFirePoint.SetActive(true);
            SoundController._instance.OnPlayAudio(SoundType.cannon_fire);
            StartCoroutine(Snatch());
            yield return new WaitForSeconds(0.2f);
            _particleFirePoint.SetActive(false);
        }

    }

    //Snatch gun
    IEnumerator Snatch()
    {
        _targetPos = new Vector3(_currentPos.x - 0.14f, _currentPos.y, 0);

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
    public void SetActiveBigFeverParticle(bool res)
    {
        _bigFever.SetActive(res);
    }
    public void SetActiveSmallFeverParticle(bool res)
    {
        _smallFever.SetActive(res);
    }
    public void DisableSupport()
    {
        _support.SetActive(false);
    }
}
