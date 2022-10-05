using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : MonoBehaviour
{
    [SerializeField] float DistanceLocalPos2Wall = 4.24f;
    public void BornNewWall()
    {
        Vector3 PosLocalLastWall = transform.GetChild(transform.childCount - 1).transform.localPosition;

    }
    public void AddWallToPool()
    {

    }
}
