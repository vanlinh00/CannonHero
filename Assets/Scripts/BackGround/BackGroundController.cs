using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : Singleton<BackGroundController>
{
    [SerializeField] GameObject _backgroundStatic;

    [SerializeField] GameObject _bgDynamic;
    [SerializeField] GameObject _bgClouds;
    [SerializeField] GameObject _bgDynamicPool;

    public bool IsFindPlayer = false;


    protected override void Awake()
    {
        base.Awake();
    }

    private void OnEnable()
    {
        StartCoroutine(WaitForLoadPlayer());
    }
    IEnumerator WaitForLoadPlayer()
    {
        yield return new WaitForEndOfFrame();
        IsFindPlayer = true;
    }
    private void FixedUpdate()
    {
        if(IsFindPlayer)
        {
            if (GameController._instance.isPlayMove)
            {
                _bgDynamic.transform.position += _bgDynamic.transform.right * 1f * Time.deltaTime;
                _bgDynamicPool.transform.position += _bgDynamicPool.transform.right * 1f * Time.deltaTime;
            }
        }
      
    }

}
