using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [SerializeField] float _moveTime;
    public Vector3 target;
    private void FixedUpdate()
    {
        if(GameController._instance.isMove)
        {
            var step = _moveTime * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            if (Vector3.Distance(transform.position, target) == 0f)
            {
                BonrNextNewPillar();
                GameController._instance.PassNextPillar();
            }
        }
       
    }
    public void MoveToTarget()
    {
        StartCoroutine(WaitTimeMoveToTarget());
    }
    IEnumerator WaitTimeMoveToTarget()
    {
        yield return new WaitForSeconds(0.5f);
        target = FindNewPosAllsPillar();
        GameController._instance.isMove = true;
        SoundController2._instance.OnPlayAudio(SoundType.footsteps_boots);
        SoundController2._instance.audioFx.loop = true;
    }
    public Vector3 FindNewPosAllsPillar()
    {
        float x = Random.RandomRange(0.95f, 2f);
        Vector3 SecondPillar = transform.GetChild(1).transform.localPosition;
        Vector3 PosAllsPillar = transform.position;
        return new Vector3(x - SecondPillar.x, PosAllsPillar.y, 0f);
    }
    public void SetUpGame()
    {
        Vector3 PosFristPillar = new Vector3(1.67f, Random.RandomRange(-3.88f, -2.4f), 0);
        CreateNewPillar(PosFristPillar);
        BonrNextNewPillar();
    }
    public void BonrNextNewPillar()
    {
        if(transform.childCount>1)
        {
            GameObject FirstPillar = transform.GetChild(0).gameObject;
            AddPillarToObjectPool(FirstPillar);
        }
 
        Vector3 PosLastPillar = transform.GetChild(transform.childCount - 1).transform.position;
        Vector3 PosNewPillar = new Vector3(PosLastPillar.x + 4.68f, Random.RandomRange(-3.88f, -2.4f),0);
        CreateNewPillar(PosNewPillar);
    }
    public void CreateNewPillar(Vector3 PosLastPillar)
    {
        GameObject NewPillar = ObjectPooler._instance.SpawnFromPool("Pillar"+GameController._instance.idBg, PosLastPillar, Quaternion.identity);
        NewPillar.transform.parent = transform;
        NewPillar.GetComponent<Pillar>().SetEnabledColliderInBody(true);
        NewPillar.GetComponent<Pillar>().ResetPillar();


    }
    public void AddPillarToObjectPool(GameObject ObjFirstPillar)
    {
        ObjFirstPillar.transform.parent = OldObjectPool._instance.transform;
        ObjectPooler._instance.AddElement("Pillar" + GameController._instance.idBg, ObjFirstPillar);
    }
     
    public GameObject GetFristPillar()
    {
        return transform.GetChild(0).gameObject;
    }
    public void ResetPillarController()
    {
        GameObject Pillar;
        int NumChild = transform.childCount;
        for (int i = 0; i < NumChild; i++)
        {
            Pillar = transform.GetChild(0).gameObject;
            Pillar.SetActive(false);
            ObjectPooler._instance.AddElement("Pillar" + GameController._instance.idBg, Pillar);
            Pillar.transform.parent = ObjectPooler._instance.transform;
        }
    }
}
