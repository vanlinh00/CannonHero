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
    private void Start()
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
    IEnumerator SetUp()
    {
        yield return new WaitForSeconds(0.4f);
        CreateWall(startPoint);
    }
    public void AddCloudToObjectPool()
    {       
        GameObject FirstBgDynamic = transform.GetChild(0).gameObject;
        FirstBgDynamic.transform.parent = ObjectPooler._instance.transform;
        ObjectPooler._instance.AddElement("Cloud", FirstBgDynamic);
    }
    public void CreateWall(Vector3 Pos)
    {
        Vector3 NewPosCloud = new Vector3(CameraController._instance.transform.position.x+Pos.x, Pos.y, 0f);
        GameObject Cloud = ObjectPooler._instance.SpawnFromPool("Cloud", NewPosCloud, Quaternion.identity);
        Cloud.transform.parent = transform;
    }
}
