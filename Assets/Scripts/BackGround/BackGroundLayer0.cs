using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundLayer0 : MonoBehaviour
{
    public void Init()
    {
        GameObject Bg1 = ObjectPooler._instance.SpawnFromPool("BgStatic1" + GameController._instance.idBg, new Vector3(0, 0, 0), Quaternion.identity);
        Bg1.transform.parent = transform;
    }
    public void ResetAllLayer()
    {
        GameObject Bg = transform.GetChild(0).gameObject;
        Bg.SetActive(false);
        ObjectPooler._instance.AddElement("BgStatic1" + GameController._instance.idBg, Bg);
        Bg.transform.parent = ObjectPooler._instance.transform;
    }
}