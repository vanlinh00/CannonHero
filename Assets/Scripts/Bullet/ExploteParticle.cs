using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploteParticle : MonoBehaviour
{
    public int isBullet;
    [SerializeField] float _timeWait;
    private void OnEnable()
    {
        StartCoroutine(WaitTimeDisable());
    }
    IEnumerator WaitTimeDisable()
    {
        yield return new WaitForSeconds(_timeWait); 
        ObjectPooler._instance.AddElement("ExplodeParticle" + isBullet, gameObject);
        this.gameObject.SetActive(false);
    }

}
