using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlatform : MonoBehaviour
{

    [SerializeField] GameObject _layer1;
    [SerializeField] GameObject _layer2;
    [SerializeField] private float _speed;
    [SerializeField] Vector3 _oriPosLayer1;
    [SerializeField] Vector3 _oriPosLayer2;

    [SerializeField] Vector3 _localPosChildLayer;
    [SerializeField] string _nameObject;
    private void Update()
    {
        if (GameController._instance.isMove)
        {
            _layer1.transform.Translate(Vector3.left * _speed * Time.deltaTime);
           _layer2.transform.Translate(Vector3.left * _speed * Time.deltaTime);

        if (_layer2.transform.position.x <= 0f)
        {
            _layer1.transform.position = _oriPosLayer1;
            _layer2.transform.position = _oriPosLayer2;
        }
        }
    }
    public void Init()
    {
        GameObject Bg1 = ObjectPooler._instance.SpawnFromPool(_nameObject + GameController._instance.idBg, new Vector3(0, 0, 0), Quaternion.identity);
        Bg1.transform.parent = _layer1.transform;
        Bg1.transform.localPosition = _localPosChildLayer;

        GameObject Bg2 = ObjectPooler._instance.SpawnFromPool(_nameObject + GameController._instance.idBg, new Vector3(0, 0, 0), Quaternion.identity);
        Bg2.transform.parent = _layer2.transform;
        Bg2.transform.localPosition = _localPosChildLayer;
    }
    public void ResetAllLayer()
    {
        ResetLayer(_layer1);
        ResetLayer(_layer2);
    }
    public void ResetLayer(GameObject layer)
    {
        GameObject Bg = layer.transform.GetChild(0).gameObject;
        Bg.SetActive(false);
        ObjectPooler._instance.AddElement(_nameObject + GameController._instance.idBg, Bg);
        Bg.transform.parent = ObjectPooler._instance.transform;
    }
}
