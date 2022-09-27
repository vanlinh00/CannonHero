using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] GameObject ParticleDead;
    private Weapon _weapon;
    public bool isRotation = false;
    public bool isShoot = false;
    private Rigidbody2D _rbComponentPlayer;
    [SerializeField] GameObject[] _objectComponentPlayer;
    [SerializeField] float _torqueSpeed=1200f;
    [SerializeField] float _force = 300f;
    [SerializeField] Animator _animator;

    // State Run
    [SerializeField] float _speedMove;
    [SerializeField] Vector3 _targetPos;
    [SerializeField] Vector3 _currentPos;
    public enum StatePlayer
    {
        Living,
        Die,
    }

    public StatePlayer statePlayer;
    private void Start()
    {
        StateIdle();
        _weapon = Weapon.GetComponent<Weapon>();
    }
    public Weapon GetWeapon()
    {
        return _weapon;
    }
    public void RotateWeapon()
    {   
        if( _weapon.currentAngleZ <= 90f)
        {
            _weapon.AutoRotate();
        }
        //if ()
        //{
        //    RotateHead();
        //}    
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
            collision.gameObject.SetActive(false);
        }
    }
    public void BreakObjectInPlayer()
    {
        for (int i = 0; i < _objectComponentPlayer.Length; i++)
        {
            if (_objectComponentPlayer[i].GetComponent<Rigidbody2D>() == null)
            {
                _objectComponentPlayer[i].GetComponent<SpriteRenderer>().color= new Color(0, 0,0);
                _rbComponentPlayer = _objectComponentPlayer[i].gameObject.AddComponent<Rigidbody2D>();
            }
            _rbComponentPlayer.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1.2f), 0f) * _force);
            _rbComponentPlayer.AddTorque(_torqueSpeed, ForceMode2D.Force);
        }
    }
    
    public void StateIdle()
    {
        _animator.SetBool("IsRun", false);
    }
    public void StateRun()
    {
        _animator.SetBool("IsRun", true);
        StartCoroutine(Run());
    }
    IEnumerator Run()
    {  
         StartCoroutine(Move(transform, _targetPos, _speedMove));
         yield return new WaitForSeconds(_speedMove);
        StartCoroutine(Move(transform, _currentPos, _speedMove));
        yield return new WaitForSeconds(_speedMove);
        StateIdle();
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
    void RotateHead()
    {
        StartCoroutine(FadeRotation(0f, 12f));
    }
    IEnumerator FadeRotation(float currentDegree, float Degree)
    {
        float t = currentDegree;
        while (t <= Degree)
        {
            yield return new WaitForEndOfFrame();
            t += 1.5f;
            Quaternion target = Quaternion.Euler(transform.rotation.x, transform.rotation.y,t );
            transform.rotation = target;
        }
    }
    //public void ResetPlayer()
    //{
    //    transform.position = new Vector3(-1.545f, -1.733f, 0);
    //    _weapon.ResetRotation();
    //}

}
