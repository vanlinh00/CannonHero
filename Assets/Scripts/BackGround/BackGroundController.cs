using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : Singleton<BackGroundController>
{
    [SerializeField] GameObject _backgroundStatic;
    [SerializeField] Vector3 _posBgStatic1;
    [SerializeField] Vector3 _posBgStatic2;

    [SerializeField] GameObject _bgDynamic;
    [SerializeField] GameObject _bgClouds;

    [SerializeField] GameObject _bgDynamicPool;

    [SerializeField] PlayerController _player;

    public bool IsFindPlayer = false;

    protected override void Awake()
    {
        base.Awake();
    }
    public void LoadBackGround()
    {
        BornBgStatic();
    }
    private void Start()
    {
        StartCoroutine(FindPlayer());
    }
    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.8f);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        IsFindPlayer = true;
    }
    private void FixedUpdate()
    {
        if(IsFindPlayer)
        {
            if (_player.isMove)
            {
                _bgDynamic.transform.position += _bgDynamic.transform.right * 1f * Time.deltaTime;
                _bgDynamicPool.transform.position += _bgDynamicPool.transform.right * 1f * Time.deltaTime;
            }
        }
      
    }
    public void BornBgStatic()
    {
        GameObject BgStatic1 =   ObjectPooler._instance.SpawnFromPool("BgStatic1", _posBgStatic1, Quaternion.identity);
        GameObject BgStatic2=  ObjectPooler._instance.SpawnFromPool("BgStatic2", _posBgStatic2, Quaternion.identity);
        BgStatic1.transform.parent = _backgroundStatic.transform;
        BgStatic2.transform.parent = _backgroundStatic.transform;
    }
  
}
