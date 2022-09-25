using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPlayer : BaseBullet
{
    public float currentTime;
    protected virtual void FixedUpdate()
    {
        if (currentTime < timeLife)
        {
            currentTime += Time.deltaTime * 2f;
            base.rigidbody.velocity = transform.right * bulletSpeed;
        }
        else
        {
            Vector3 VectorVelocity = base.rigidbody.velocity.normalized;
            Vector3 targetDir = transform.TransformDirection(Vector3.right);
            //float angle = FindAngleBetweenVector(VectorVelocity, targetDir);
            float angle = Vector3.SignedAngle(targetDir, VectorVelocity, Vector3.forward);
            transform.Rotate(Vector3.forward, angle, Space.World);
        }
    }
}
