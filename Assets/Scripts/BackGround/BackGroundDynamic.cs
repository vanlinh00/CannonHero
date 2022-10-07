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
    private void OnEnable()
    {
        StartCoroutine(LoadPlayer());
    }
    IEnumerator LoadPlayer()
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
        CreateBgDynamic(LocalPosNewWall);
    }
    public void AddWallToObjectPool()
    {
        GameObject FirstBgDynamic = transform.GetChild(0).gameObject;
        FirstBgDynamic.transform.parent = _BgDynamicPool.transform;/* ObjectPooler._instance.transform;*/
        ObjectPooler._instance.AddElement("BgDynamic"+GameController._instance.idBg, FirstBgDynamic);
    }
    public void CreateBgDynamic(Vector3 localPos)
    {
        GameObject Wall = ObjectPooler._instance.SpawnFromPool("BgDynamic"+ GameController._instance.idBg, new Vector3(0, 0, 0), Quaternion.identity);
        Wall.transform.parent = transform;
        Wall.transform.localPosition = localPos;
    }
    public void SetUp()
    {
        Vector3 startLocalPos = new Vector3(0f, 0f, 0f);
        CreateBgDynamic(startLocalPos);
        BornNewBgDynamic();
    }

    public void ResetAllBackGroundDynamic()
    {
        GameObject Bgdynamic;
        int NumChild = transform.childCount;
        for (int i = 0; i < NumChild; i++)
        {
            Bgdynamic = transform.GetChild(0).gameObject;
            Bgdynamic.SetActive(false);
            ObjectPooler._instance.AddElement("BgDynamic"+GameController._instance.idBg , Bgdynamic);
            Bgdynamic.transform.parent = ObjectPooler._instance.transform;
        }
        ResetBgDynamic();
        transform.position = new Vector3(-1.49f, -2.65f, 0);
    }
    public void ResetBgDynamic()
    {
        GameObject Bgdynamic;
        int NumChild = _BgDynamicPool.transform.childCount;
        for (int i = 0; i < NumChild; i++)
        {
            Bgdynamic = _BgDynamicPool.transform.GetChild(0).gameObject;
            Bgdynamic.SetActive(false);
            ObjectPooler._instance.AddElement("BgDynamic" + GameController._instance.idBg, Bgdynamic);
            Bgdynamic.transform.parent = ObjectPooler._instance.transform;
        }
    }
}
