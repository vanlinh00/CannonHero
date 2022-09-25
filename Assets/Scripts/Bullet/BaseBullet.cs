using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBullet : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    public float bulletSpeed;
    protected virtual void OnEnable()
    {
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }
 
}
