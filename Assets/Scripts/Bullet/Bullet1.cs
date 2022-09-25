using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : BulletPlayer
{
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = transform.right * bulletSpeed;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
    }
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
