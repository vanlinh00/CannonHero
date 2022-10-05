﻿using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController :MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject ParticleDead;

    private WeaponPlayer _weapon;
    public bool isRotation = false;
    public bool isShoot = false;
    private Rigidbody2D _rbComponentPlayer;

    [SerializeField] GameObject[] _objectComponentPlayer;
    private List<Vector3> _localPosComponent;

    [SerializeField] float _torqueSpeed=1200f;
    [SerializeField] float _force = 300f;
    [SerializeField] Animator _animator;

    // State Run
    [SerializeField] float _speedMove;
    [SerializeField] Vector3 _targetPos;
    [SerializeField] Vector3 _currentPos;

    // Rotate Head
    public bool isRotateHead = false;
    public enum StatePlayer
    {
        Living,
        Die,
    }

    public StatePlayer statePlayer;
    public bool isEnableTrail=true;

    public bool isMove = false;
    [SerializeField] float _moveTime;
    public Vector3 target;
    public bool isEnableStateIdle = true;
    private void Start()
    {
        _localPosComponent = new List<Vector3>();
        StateIdle();
        _weapon = Weapon.GetComponent<WeaponPlayer>();
    }
    private void FixedUpdate()
    {
        if (isMove)
        {
            var step = _moveTime * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if (Vector3.Distance(transform.position, target) == 0f)
            {
                isMove = false;
                isEnableStateIdle = true;
                isEnableTrail = true;
            }
        }
        else
        {
            if (isEnableStateIdle)
            {
                StateIdle();
                isEnableStateIdle = false;
            }
        }
    }
    public WeaponPlayer GetWeapon()
    {
        return _weapon;
    }
    public void RotateWeapon()
    {   
        if( _weapon.currentAngleZ <= 90.3f)
        {
            if (isEnableTrail)
            {
               GetWeapon().SetEnableTrail();

                isEnableTrail = false;
            }
            _weapon.AutoRotate();
        }
    }

    public void WeaponShoot()
    {
       _weapon.Shoot();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Bullet"))
        {
            statePlayer = StatePlayer.Die;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            _animator.enabled = false;
            ParticleDead.SetActive(true);
            BreakObjectInPlayer();
        }
    }
    public void BreakObjectInPlayer()
    {
        for (int i = 0; i < _objectComponentPlayer.Length; i++)
        {
            if (_objectComponentPlayer[i].GetComponent<Rigidbody2D>() == null)
            {
                _localPosComponent.Add(_objectComponentPlayer[i].transform.localPosition);
                _objectComponentPlayer[i].GetComponent<SpriteRenderer>().color= new Color(0, 0,0);
                _rbComponentPlayer = _objectComponentPlayer[i].gameObject.AddComponent<Rigidbody2D>();
            }
            _rbComponentPlayer.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1.2f), 0f) * _force);
            _rbComponentPlayer.AddTorque(_torqueSpeed, ForceMode2D.Force);
        }
    }
    public void ResetComponentInPlayer()
    {
        for (int i = 0; i < _objectComponentPlayer.Length; i++)
        {
            if (_objectComponentPlayer[i].GetComponent<Rigidbody2D>() != null)
            {   
                _objectComponentPlayer[i].GetComponent<SpriteRenderer>().color = new Color(255, 255,255,255);
                 Destroy(_objectComponentPlayer[i].GetComponent<Rigidbody2D>());
                _objectComponentPlayer[i].transform.localPosition = _localPosComponent[i];
                _objectComponentPlayer[i].transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }
   public void RecurrectPlayer()
    {
        GetWeapon().ResetRotation();
        ResetComponentInPlayer();
        statePlayer = StatePlayer.Living;
        _animator.enabled = true;
        StateIdle();
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        ParticleDead.SetActive(false);
    }
    public void StateIdle()
    {
        _animator.SetBool("IsRun", false);
        _animator.SetBool("RotateHead", false);
    }
    public void StateRun()
    {
        _animator.SetBool("IsRun", true);
    }
    public void RotateHead()
    {
        if(!isRotateHead)
        {
            StateRotate();
            isRotateHead = true;
        }
    }
    public void StateRotate()
    {
        _animator.SetBool("IsRun", false);
        _animator.SetBool("RotateHead", true);
    }   

    public void MoveToNextPillar()
    {
        isMove = true;
        StateRun();
    }
    public float GetTimeSpeed()
    {
        return _speedMove;
    }


}
