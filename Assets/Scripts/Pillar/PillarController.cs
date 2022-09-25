using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    // Max -4.69
    // Min-5.61
    [SerializeField] float _moveSpeed = 1f;
    [SerializeField] float _dis2Pillar = 4.76f;
    public void MoveToTarget()
    {
        Vector3 Target = new Vector3(transform.position.x+ Random.RandomRange(-5.61f, -4.69f),transform.position.y , 0);
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
    public void BonrNewPillar()
    {
        Vector3 PosChildNode = transform.GetChild(transform.childCount - 1).transform.position;
        // Vector3 PosChildNode
        ObjectPooler._instance.SpawnFromPool("Pillar", new Vector3(0, 0, 0), Quaternion.identity);
    }
    public void GetCurrentPillar()
    {

    }
}
