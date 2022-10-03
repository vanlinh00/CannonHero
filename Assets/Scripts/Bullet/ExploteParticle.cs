using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploteParticle : MonoBehaviour
{
    private void OnEnable()
    {
        Debug.Log("ExploteParticle");
        StartCoroutine(WaitTimeDisable());
    }
    IEnumerator WaitTimeDisable()
    {
        yield return new WaitForSeconds(1f);
        ObjectPooler._instance.AddElement("ExplodePartile", gameObject);
        this.gameObject.SetActive(false);
    }

}
