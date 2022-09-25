using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float _force;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;

    void Start()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
        _rigidbody2D.AddForce(new Vector3(Random.RandomRange(-0.15f, 0.15f), 0.3f, 0f) * _force);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            StateReduceColor();
        }
    }
   void StateIdle()
    {
        _animator.SetBool("ReduceColor", false);
    }
    void StateReduceColor()
    {
        _animator.SetBool("ReduceColor", true);
    }
}
