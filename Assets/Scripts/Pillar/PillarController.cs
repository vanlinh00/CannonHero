using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _dis2Pillar = 4.76f;
    public void MoveToTarget()
    {
        gameObject.transform.GetChild(0).GetComponent<Pillar>().SetEnabledColliderInBody(false);
        float A = Random.RandomRange(0.89f, 1.53f);
        float PosX = A - transform.GetChild(1).transform.localPosition.x;
        Vector3 Target = new Vector3(PosX,transform.position.y, 0);
        StartCoroutine(Move(transform, Target, _moveSpeed));
    }
    IEnumerator Move(Transform CurrentTransform, Vector3 Target, float TotalTime)
    {
        var passed = 0f;
        var init = CurrentTransform.transform.position;
        while (passed < TotalTime)
        {
            passed += Time.deltaTime;
            var normalized = passed / TotalTime;
            var current = Vector3.Lerp(init, Target, normalized);
            CurrentTransform.position = current;
            yield return null;
        }
    }
    public void BonrNextNewPillar()
    {   
        GameObject FirstPillar = transform.GetChild(0).gameObject;
        AddPillarToObjectPool(FirstPillar);
        Vector3 PosLastPillar = transform.GetChild(transform.childCount - 1).transform.position;
        GameObject NewPillar = ObjectPooler._instance.SpawnFromPool("Pillar", new Vector3(PosLastPillar.x + 4.68f, Random.RandomRange(-3.88f, -2f), 0), Quaternion.identity);
        
        NewPillar.GetComponent<Pillar>().SetEnabledColliderInBody(true);
        NewPillar.GetComponent<Pillar>().ResetPillar();

        NewPillar.transform.parent = transform;
    }
    public void AddPillarToObjectPool(GameObject ObjFirstPillar)
    {
        Pillar FirstPillar = ObjFirstPillar.GetComponent<Pillar>();
        ObjFirstPillar.transform.parent = ObjectPooler._instance.transform;
        ObjectPooler._instance.AddElement("Pillar", ObjFirstPillar);
       /// ObjFirstPillar.SetActive(false);
    }
    public void BonrFirstPillar()
    { 
       GameObject FirstPillar = ObjectPooler._instance.SpawnFromPool("Pillar", new Vector3(Random.RandomRange(0.89f, 1.82f), Random.RandomRange(-3.88f, -2f), 0), Quaternion.identity);
       FirstPillar.transform.parent = transform;
    }
    //public void ResetPillarController()
    //{
    //    GameObject Pillar;
    //    for (int i = 0; i < transform.childCount; ++i)
    //    {
    //        Pillar = transform.GetChild(0).gameObject;
    //        Pillar.SetActive(false);
    //        ObjectPooler._instance.AddElement("Pillar", Pillar);
    //        Pillar.transform.parent = ObjectPooler._instance.transform;
    //    }
    //    transform.position = new Vector3(0, 0, 0);
    //    BonrFirstPillar();
    //}
}
