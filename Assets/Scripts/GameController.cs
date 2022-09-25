using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject _currentPillar;
    [SerializeField] PlayerController _player;

    [SerializeField] EnemyController _currentEnemy;

    [SerializeField] PillarController _pillarController;
    private bool _isContinueGame = true;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        _currentPillar = _pillarController.gameObject.transform.GetChild(0).gameObject;
        _currentEnemy = _currentPillar.transform.GetChild(0).gameObject.GetComponent<EnemyController>();
    }
    private void Update()
    {
    //    if(_isContinueGame)
    //    {
            if (Input.GetMouseButton(0))
            {
                _player.RotateWeapon();
            }
            if (Input.GetMouseButtonUp(0))
            {
                _player.WeaponShoot();
                StartCoroutine(CheckEnemyShoot());
            }
       // }
     
    }
    IEnumerator CheckEnemyShoot()
    {
        yield return new WaitForSeconds(2.2f);

        if (_currentEnemy._stateEnemy == EnemyController.StateEnemy.Die)
        {
            _pillarController.MoveToTarget();
        }
        else
        {
            if(_player.statePlayer==PlayerController.StatePlayer.Die)
            {

            }
            else
            {
                _currentEnemy.Shoot();
            }
            
        }
    }
}
