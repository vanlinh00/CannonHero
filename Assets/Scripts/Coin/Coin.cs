using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float _force;
    [SerializeField] SpriteRenderer _spriteRenderer;
    [SerializeField] Animator _animator;

    private void OnEnable()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }
    public void AddForce()
    {
        float x = 0f;
        if(Random.RandomRange(1,3)==2)
        {
            x = Random.RandomRange(-0.1f, -0.09f);

        }
        else
        {
            x = Random.RandomRange(0.05f, 0.15f);
        }

        _rigidbody2D.AddForce(new Vector3(x, 0.7f, 0f) * _force);
    }
    public void ResetColorCoin()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")|| collision.gameObject.CompareTag("BodyPlayer"))
        {
            StartCoroutine(WaitAddToPool());
        }
    }
   IEnumerator WaitAddToPool()
    {
        StateReduceColor();
        yield return new WaitForSeconds(0.47f);
        StateIdle();
        yield return new WaitForSeconds(0.1f);
        this.gameObject.SetActive(false);
    }
  public void StateIdle()
    {
        _animator.SetBool("ReduceColor", false);
    }
    public void StateReduceColor()
    {
        _animator.SetBool("ReduceColor", true);
    }
}
