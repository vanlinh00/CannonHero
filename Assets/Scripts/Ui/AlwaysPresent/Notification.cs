using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notification : MonoBehaviour
{
    [SerializeField] CanvasGroup _canvasGroup;
    public Text notificationTxt;
    private void OnEnable()
    {
        StartCoroutine(WaitDisableGameObject());
    }
    IEnumerator WaitDisableGameObject()
    {
        while(_canvasGroup.alpha>0)
        {    
            yield return new WaitForEndOfFrame();
           _canvasGroup.alpha = _canvasGroup.alpha - 0.005f;
          
        }
        _canvasGroup.alpha = 1;
        gameObject.SetActive(false);
    }

}
