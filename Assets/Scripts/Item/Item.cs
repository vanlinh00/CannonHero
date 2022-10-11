using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] float _force;
    [SerializeField] Animator _animator;

    private void OnEnable()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }
    public void AddForce()
    {
        _rigidbody2D.AddForce(new Vector3(Random.RandomRange(-0.28f,0.33f), Random.RandomRange(0.3f, 0.65f), 0f) * Random.RandomRange(_force-100,_force+100));
    }
    public void ResetCoin()
    {
        GetComponent<Rigidbody2D>().gravityScale = 1f;
        GetComponent<CircleCollider2D>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall")/*|| collision.gameObject.CompareTag("HeadEnemy")|| collision.gameObject.CompareTag("BodyPillar")*/)
        {
            SoundController._instance.OnPlayAudio(SoundType.Coin);
            AlwaysPresent._instance.CountCoins();
            GetComponent<CircleCollider2D>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<Rigidbody2D>().AddTorque(500f, ForceMode2D.Force);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
            StartCoroutine(WaitAddToPool());

        }
        else if (collision.gameObject.CompareTag("BodyPillar"))
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 100f));
        }
    }
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Wall")/*|| collision.gameObject.CompareTag("HeadEnemy")|| collision.gameObject.CompareTag("BodyPillar")*/)
    //    {
    //        SoundController._instance.OnPlayAudio(SoundType.Coin);
    //        AlwaysPresent._instance.CountCoins();
    //        GetComponent<CircleCollider2D>().enabled = false;
    //        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    //        GetComponent<Rigidbody2D>().gravityScale = 0f;
    //        GetComponent<Rigidbody2D>().AddTorque(500f, ForceMode2D.Force);
    //        GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 200f));
    //        StartCoroutine(WaitAddToPool());

    //    }
    //    //else if (collision.gameObject.CompareTag("BodyPillar"))
    //    //{
    //    //    GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 100f));
    //    //}
    //}
    IEnumerator WaitAddToPool()
    {
        StateReduceColor();
        yield return new WaitForSeconds(0.35f);
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
