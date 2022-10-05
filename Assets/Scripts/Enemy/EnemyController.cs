﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _force;
    [SerializeField] float _torqueSpeed;
    private WeaponEnemy _weapon;
    public bool isCurrentEnemy;
    public Vector3 _posEnemy;

    // Component Enemy
    [SerializeField] GameObject _head;
    [SerializeField] GameObject _body;
    [SerializeField] GameObject _feet;

    public bool isBornCoin;

    public bool isHitHead;
    public bool isHitBody;
    public bool isHitFeet;

    public PlayerController _player;
    public enum StateEnemy
    {
        Living,
        Die,
    }
    public StateEnemy _stateEnemy;
    void Start()
    {
        isHitHead = false;
        isHitBody = false;
        isHitFeet = false;
        isBornCoin = true;
        _weapon = Weapon.GetComponent<WeaponEnemy>();
        StartCoroutine(WaitTimeForUpdatePlayer());
    }
    private void Awake()
    {
        isCurrentEnemy = false;
    }
    IEnumerator WaitTimeForUpdatePlayer()
    {
        yield return new WaitForEndOfFrame();
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (GameController._instance.IsGameOver)
        {
            if (_player.statePlayer != PlayerController.StatePlayer.Die&& isCurrentEnemy && _stateEnemy != StateEnemy.Die)
            {
                isCurrentEnemy = false;
                Shoot();
            }
        }
       
    }

   public void Die()
    {
        if(isBornCoin)
        {
            Vector3 PosCoin = new Vector3(_head.transform.position.x, _head.transform.position.y + 0.2f, 0f);
            gameObject.transform.parent.transform.parent.GetComponent<Pillar>().BornCoins(PosCoin);
            if (GameController._instance.IsFever)
            {
                gameObject.transform.parent.transform.parent.GetComponent<Pillar>().BornDiamonds(PosCoin);
            }
            isBornCoin = false;
        }
        _stateEnemy = StateEnemy.Die;

        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
            AddRigibody();
            _rigidbody2D.AddForce(new Vector3(0.2f, 0.7f, 0f) * _force);
            _rigidbody2D.AddTorque(_torqueSpeed, ForceMode2D.Force);
            _head.GetComponent<PolygonCollider2D>().enabled = false;
            _body.GetComponent<BoxCollider2D>().enabled = false;
            _feet.GetComponent<BoxCollider2D>().enabled = false;
       }
    }
    public void AddRigibody()
    {
       _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
    }
    public void RemoveRigibody()
    {
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }
    void WeaPonRotateToPlayer()
    {
        Vector3 VectorA = _weapon.PosFirePoint() -Weapon.transform.position;
        Vector3 VectorB = _player.transform.position - Weapon.transform.position;
        float angle = Vector2.Angle(VectorA, VectorB);
        StartCoroutine(_weapon.FadeRotateToTarget(0, angle));
    }
    public Weapon GetWeapon()
    {
        return _weapon;
    }
  public void Shoot()
    {
        StartCoroutine(WaitTimeShoot());
    }
    IEnumerator WaitTimeShoot()
    {  
        WeaPonRotateToPlayer();
        yield return new WaitForSeconds(1f);
        _weapon.Shoot();
    }
    public void ResetEnemy()
    {
        isBornCoin = true;
        isCurrentEnemy = false;
        _weapon = Weapon.GetComponent<WeaponEnemy>();

        _stateEnemy = StateEnemy.Living;
        transform.localPosition = _posEnemy;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        isCurrentEnemy = false;
        _head.GetComponent<PolygonCollider2D>().enabled = true;
        _body.GetComponent<BoxCollider2D>().enabled = true;
        _feet.GetComponent<BoxCollider2D>().enabled = true;

        _head.GetComponent<HeadEnemy>().ParticleBoolHead.SetActive(false);

        isHitHead = false;
        isHitBody = false;
        isHitFeet = false;
    }
}
