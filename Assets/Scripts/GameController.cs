using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _currentPillar;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }
}
