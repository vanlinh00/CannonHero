using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] Button RestartBtn;
    private void Awake()
    {
        RestartBtn.onClick.AddListener(RestartGame);
    }
    void Start()
    {
        
    }
    void RestartGame()
    {
         SceneManager.LoadScene(0);
       //  GameController._instance.LoadScenceAgain();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
