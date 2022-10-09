using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : Singleton<WallController>
{
    [SerializeField] MoveFlatform _allWalls;

    public void Init()
    {
        _allWalls.Init();
    }
    public void ResetAllWalls()
    {
        _allWalls.ResetAllLayer();

    }

}
