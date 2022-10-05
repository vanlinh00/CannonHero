using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : BaseBullet
{
    [SerializeField] Vector3 _localScale;
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
    protected virtual void FixedUpdate()
    {
        Vector3 VectorVelocity = base.rigidbody.velocity.normalized;
        Vector3 targetDir = transform.TransformDirection(Vector3.right);
        float angle = Vector3.SignedAngle(targetDir, VectorVelocity, Vector3.forward);
        transform.Rotate(Vector3.forward, angle, Space.World);
    }
    public void SetUp()
    {
        if (stateBullet == StateBullet.Fiver)
        {
            transform.localScale = new Vector3(transform.localScale.x * 1.8f, transform.localScale.y * 1.8f, 0);
        }
        else
        {
            transform.localScale = new Vector3(_localScale.x,_localScale.y, 0);
        }

    }
}
