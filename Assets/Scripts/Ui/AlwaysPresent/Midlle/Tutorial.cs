using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] Text _tutorialTxt;
    [SerializeField] CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        StartCoroutine(FadeDisableObj());
    }

    IEnumerator FadeDisableObj()
    {
        while(_canvasGroup.alpha>0)
        {
            yield return new WaitForEndOfFrame();
            _canvasGroup.alpha = _canvasGroup.alpha - 0.01f;
        }
        _canvasGroup.alpha = 1;
        this.gameObject.SetActive(false);
    }
}
