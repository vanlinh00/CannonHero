using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OldObjectPool : Singleton<OldObjectPool>
{
    protected override void Awake()
    {
        base.Awake();
    }
    public void SettDisableAllObject()
    {
        GameObject Pillar;
        int NumChild = transform.childCount;
        for (int i = 0; i < NumChild; i++)
        {
            Pillar = transform.GetChild(0).gameObject;
            Pillar.transform.parent = ObjectPooler._instance.transform;
            Pillar.SetActive(false);
        }

    }
}
