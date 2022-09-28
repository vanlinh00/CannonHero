using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHome : MonoBehaviour
{
    [SerializeField] Button _startGamePlayBtn;
    private void Awake()
    {
        _startGamePlayBtn.onClick.AddListener(OpenGamePlay);
    }
    public void OpenGamePlay()
    {
        AlwaysPresent._instance.SetActiveTutorial(false);
        UiController._instance.OpenGamePlay();
    }
}
