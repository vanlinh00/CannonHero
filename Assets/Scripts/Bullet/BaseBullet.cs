using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public enum StateBullet
    {
        Fiver,
        Normal,
    }
    public StateBullet stateBullet;

    protected virtual void Start()
    {
        stateBullet = StateBullet.Normal;
    }

    public Rigidbody2D rigidbody;
    public float bulletSpeed;

    public void SetUp()
    {
        if (stateBullet == StateBullet.Fiver)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.8f, transform.localScale.y * 1.8f, 0);
        }
        else
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, 0);
        }

    }
}
