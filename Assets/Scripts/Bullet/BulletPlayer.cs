using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : BaseBullet
{
    protected virtual void FixedUpdate()
    {
        Vector3 VectorVelocity = base.rigidbody.velocity.normalized;
        Vector3 targetDir = transform.TransformDirection(Vector3.right);
        float angle = Vector3.SignedAngle(targetDir, VectorVelocity, Vector3.forward);
        transform.Rotate(Vector3.forward, angle, Space.World);
    }
}
