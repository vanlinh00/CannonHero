using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BackGroundDynamic : Singleton<BackGroundDynamic>
{
    [SerializeField] float _distanceLocalPos2Bg = 8.5f;
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _BgDynamicPool;
    public bool isCrateBg = false;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        StartCoroutine(WaitTimeLoadPlayer());
    }
    IEnumerator WaitTimeLoadPlayer()
    {
        yield return new WaitForSeconds(1f);
        _player = GameObject.FindGameObjectWithTag("Player");
        isCrateBg = true;
    }
    private void Update()
    {
        Vector3 PosLastWall = transform.GetChild(transform.childCount - 1).transform.position;
        if (isCrateBg)
        {
            if (Vector3.Distance(PosLastWall, _player.transform.position) <= _distanceLocalPos2Bg)
            {
                BornNewBgDynamic();
                AddWallToObjectPool();
                isCrateBg = false;
            }
        }

    }

    public void BornNewBgDynamic()
    {
        Vector3 LocalPosLastWall = transform.GetChild(transform.childCount - 1).transform.localPosition;
        Vector3 LocalPosNewWall = new Vector3(LocalPosLastWall.x + _distanceLocalPos2Bg, LocalPosLastWall.y, 0f);
        CreateWall(LocalPosNewWall);
    }
    public void AddWallToObjectPool()
    {
        GameObject FirstBgDynamic = transform.GetChild(0).gameObject;
        FirstBgDynamic.transform.parent = _BgDynamicPool.transform;/* ObjectPooler._instance.transform;*/
        ObjectPooler._instance.AddElement("BgDynamic", FirstBgDynamic);
    }
    public void CreateWall(Vector3 localPos)
    {
        GameObject Wall = ObjectPooler._instance.SpawnFromPool("BgDynamic", new Vector3(0, 0, 0), Quaternion.identity);
        Wall.transform.parent = transform;
        Wall.transform.localPosition = localPos;
    }
    public void SetUp()
    {
        Vector3 startLocalPos = new Vector3(0f, 0f, 0f);
        CreateWall(startLocalPos);
        BornNewBgDynamic();
    }
}
