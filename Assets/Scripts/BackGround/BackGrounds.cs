using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGrounds : MonoBehaviour
{
    [SerializeField] MoveFlatform _bgLayer1;
    [SerializeField] MoveFlatform _bgLayer2;
    [SerializeField] BackGroundLayer0 _bgLayer0;
    [SerializeField] CloudController _cloudController;
    
    public void Init()
    {
        _bgLayer1.Init();
        _bgLayer2.Init();
        _bgLayer0.Init();
        _cloudController.Init();
    }
    public void ResetBg()
    {
        _bgLayer1.ResetAllLayer();
        _bgLayer2.ResetAllLayer();
        _bgLayer0.ResetAllLayer();
        _cloudController.ResetClouds();
    }
}
