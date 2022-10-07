using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallController : Singleton<WallController>
{
    [SerializeField] float _distanceLocalPos2Wall = 4.24f;
    [SerializeField] GameObject _player;
    public bool isCrateWall = false;
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        StartCoroutine(WaitTimeLoadPlayer());
    }
    IEnumerator WaitTimeLoadPlayer()
    {
        yield return new WaitForSeconds(1f);
        _player = GameObject.FindGameObjectWithTag("Player");
        isCrateWall = true;
    }
    private void Update()
    {
         if ( isCrateWall)
        {
            Vector3 PosLastWall = transform.GetChild(transform.childCount - 1).transform.position;
            if (Vector3.Distance(PosLastWall, _player.transform.position) <= 4.26f)
            {
                BornNewWall();
                AddWallToObjectPool();
                isCrateWall = false;
            }
        }
    }
    public void BornNewWall()
    {  
            Vector3 LocalPosLastWall = transform.GetChild(transform.childCount - 1).transform.localPosition;
            Vector3 LocalPosNewWall = new Vector3(LocalPosLastWall.x + _distanceLocalPos2Wall, LocalPosLastWall.y, 0f);
            CreateWall(LocalPosNewWall);
    }
    public void AddWallToObjectPool()
    {
        GameObject FirstWall = transform.GetChild(0).gameObject;
        FirstWall.transform.parent = OldObjectPool._instance.transform;
        ObjectPooler._instance.AddElement("Wall"+GameController._instance.idBg, FirstWall);
    }
    public void CreateWall(Vector3 localPos)
    {
        GameObject Wall = ObjectPooler._instance.SpawnFromPool("Wall"+ GameController._instance.idBg, new Vector3(0, 0, 0), Quaternion.identity);
        Wall.transform.parent = transform;
        Wall.transform.localPosition = localPos;
    }
    public void SetUp()
    {
        Vector3 startLocalPos = new Vector3(-1.67f, 0f, 0f);
        CreateWall(startLocalPos);
        BornNewWall();
    }
    public void ResetAllWalls()
    {
        GameObject Wall;
        int NumChild = transform.childCount;  
        for (int i = 0; i < NumChild; i++)
        {
            Wall = transform.GetChild(0).gameObject;
            Wall.SetActive(false);
            ObjectPooler._instance.AddElement("Wall"+ GameController._instance.idBg, Wall);
            Wall.transform.parent = ObjectPooler._instance.transform;
        }
    }
}
