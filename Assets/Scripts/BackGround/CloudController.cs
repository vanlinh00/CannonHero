using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : Singleton<CloudController>
{
    public bool IsFindPlayer = false;
    private PlayerController _player;
    [SerializeField] Vector3 finalPoint;
    [SerializeField] Vector3 startPoint;

    public void FixedUpdate()
    {
        if(IsFindPlayer)
        {
            if (transform.GetChild(0).position.x<=finalPoint.x+CameraController._instance.transform.position.x)
            {
                CreateWall(startPoint);
                AddCloudToObjectPool();
            }
        }
    }
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
    {
        StartCoroutine(FindPlayer());
        StartCoroutine(SetUp());
    }
    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.4f);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        IsFindPlayer = true;
    }

 public  IEnumerator SetUp()
    {
        yield return new WaitForSeconds(0.4f);
        CreateWall(startPoint);
        IsFindPlayer = true;
    }
    public void AddCloudToObjectPool()
    {       
        GameObject FirstClouds = transform.GetChild(0).gameObject;
        FirstClouds.transform.parent = OldObjectPool._instance.transform;
        ObjectPooler._instance.AddElement("Cloud" + GameController._instance.idBg, FirstClouds);
    }
    public void CreateWall(Vector3 Pos)
    {
        Vector3 NewPosCloud = new Vector3(CameraController._instance.transform.position.x+Pos.x, Pos.y, 0f);
        GameObject Cloud = ObjectPooler._instance.SpawnFromPool("Cloud"+GameController._instance.idBg, NewPosCloud, Quaternion.identity);
        Cloud.transform.parent = transform;
    }
    public void ResetAllClouds()
    {
        GameObject Cloud;
        int NumChild = transform.childCount;
        for (int i = 0; i < NumChild; i++)
        {
            Cloud = transform.GetChild(0).gameObject;
            Cloud.SetActive(false);
            ObjectPooler._instance.AddElement("Cloud" + GameController._instance.idBg, Cloud);
            Cloud.transform.parent = ObjectPooler._instance.transform;
        }
        IsFindPlayer = false;
    }
}
