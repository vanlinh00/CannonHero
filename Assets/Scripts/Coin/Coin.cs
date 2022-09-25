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
        _rigidbody2D.AddForce(new Vector3(0, 0.2f, 0f) * _force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            StateReduceColor();
            //StartCoroutine(FadeChangeColor());
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
    IEnumerator FadeChangeColor()
    {

        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        float AphaSprite = _spriteRenderer.color.a;
        if (AphaSprite != 0)
        {
            byte CurrentColorA = 255;
            while (CurrentColorA > 0)
            {
                yield return new WaitForEndOfFrame();
                CurrentColorA -= 2;
                Debug.Log(CurrentColorA);
                if (CurrentColorA == (byte)254)
                {
                    CurrentColorA = (byte)0;
                }
                _spriteRenderer.color = new Color32(255, 255, 255, CurrentColorA);
            }
        }
        else
        {
            gameObject.SetActive(false);
        }

    }
}
