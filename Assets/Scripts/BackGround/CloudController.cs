using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : Singleton<CloudController>
{
    [SerializeField] float _startPoX;
    [SerializeField] float _startPoY;
    [SerializeField] float _limitPosX;
    [SerializeField] float _speed;
   public void Init()
    {
        GameObject Cloud = ObjectPooler._instance.SpawnFromPool("Cloud" + GameController._instance.idBg,new Vector3(_startPoX,Random.RandomRange(_startPoY,_startPoY+1f),0), Quaternion.identity);
        Cloud cloud = Cloud.GetComponent<Cloud>();
        cloud.speed = Random.RandomRange(_speed - 0.2f, _speed + 0.2f);
        cloud.startX = _startPoX;
        cloud.limitX = _limitPosX;
        cloud.startY = _startPoY;
        Cloud.transform.parent = transform;
    }
    public void ResetClouds()
    {
        GameObject Cloud = transform.GetChild(0).gameObject;
        Cloud.SetActive(false);
        ObjectPooler._instance.AddElement("Cloud" + GameController._instance.idBg, Cloud);
        Cloud.transform.parent = ObjectPooler._instance.transform;
    }
}
