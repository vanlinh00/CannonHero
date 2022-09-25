using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] Vector3 _posPlayer;
    [SerializeField] GameObject Weapon;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _force;
    [SerializeField] float _torqueSpeed;
    private Weapon _weapon;
    private bool _isDie = false;
    public enum StateEnemy
    {
        Living,
        Die,
    }
    public StateEnemy _stateEnemy;
    void Start()
    {
        _weapon = Weapon.GetComponent<Weapon>();
        _posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
        StartCoroutine(WaitTimeShoot());
    }
   public void Die()
    {
        if(gameObject.GetComponent<Rigidbody2D>()==null)
        {
            _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
            _rigidbody2D.AddForce(new Vector3(0.2f, 0.7f, 0f) * _force);
            _rigidbody2D.AddTorque(_torqueSpeed, ForceMode2D.Force);
        }

    }
    void WeaPonRotateToPlayer()
    {
        Vector3 VectorA = _weapon.FirePoint() -Weapon.transform.position;
        Vector3 VectorB = _posPlayer-Weapon.transform.position;
        float angle = Vector2.Angle(VectorA, VectorB);
        StartCoroutine(_weapon.FadeRotateToTarget(0, angle));
    }
    IEnumerator WaitTimeShoot()
    {  
        WeaPonRotateToPlayer();
        yield return new WaitForSeconds(1f);
        _weapon.Shoot();
    }
}
