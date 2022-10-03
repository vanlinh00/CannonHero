using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineBullet3 : MonoBehaviour
{
    [SerializeField] LineRenderer _lineRenderer;
    void Start()
    {
        //Debug.Log(_lineRenderer.startWidth);
        //Debug.Log(_lineRenderer.endWidth);
       
        //_lineRenderer.colorGradient.mode.get
        // A simple 2 color gradient with a fixed alpha of 1.0f.
      
    }

  public  void WaitTime()
    {
        StartCoroutine(WaitTimeDisable());

    }
    IEnumerator WaitTimeDisable()
    {
        float alpha = 1f;
        while (alpha>0f)
        {
            yield return new WaitForEndOfFrame();
            Gradient gradient = new Gradient();
            gradient.SetKeys(
                new GradientColorKey[] { new GradientColorKey(Color.red, 0.0f), new GradientColorKey(Color.red, 1.0f) },
                new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
            );
            _lineRenderer.colorGradient = gradient;
            alpha = alpha - 0.01f;
            Debug.Log(alpha);
            _lineRenderer.startWidth = _lineRenderer.startWidth - 0.001f;
            _lineRenderer.endWidth = _lineRenderer.endWidth - 0.001f;
        }
    }
}
