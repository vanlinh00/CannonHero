using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploteParticle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(WaitTimeDisable());
    }
    IEnumerator WaitTimeDisable()
    {
        yield return new WaitForSeconds(0.4f);
        ObjectPooler._instance.AddElement("ExplodePartile", gameObject);
        this.gameObject.SetActive(false);
    }
}
