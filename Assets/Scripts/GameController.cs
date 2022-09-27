using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    [SerializeField] Pillar _currentPillar;
    [SerializeField] PlayerController _player;

    [SerializeField] EnemyController _currentEnemy;
    [SerializeField] PillarController _pillarController;

    public bool IsGameOver = false;
    [SerializeField] GameObject _camera;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && !_player.isRotation)
        {
            _player.RotateWeapon();
        }
        if (Input.GetMouseButtonUp(0) && !_player.isShoot)
        {
            _player.WeaponShoot();
            _player.isShoot = true;
            _player.isRotation = true;
            UpDatePassPillar();
        }
        if (_player.isShoot)
        {
            if (_currentEnemy._stateEnemy == EnemyController.StateEnemy.Die)
            {
                _player.isShoot = false;
                StartCoroutine(WaitTimeMoveToTarget());
            }
        }
    }
    IEnumerator WaitTimeMoveToTarget()
    {
        yield return new WaitForSeconds(0.8f);
        _player.GetWeapon().ResetRotation();
        _pillarController.MoveToTarget();
        _player.StateRun();
        yield return new WaitForSeconds(1f);
        _pillarController.BonrNextNewPillar();
        _player.isRotation = false;
        yield return new WaitForSeconds(0.35f);
        CoinManager._instance.AddCoinsToPool();
    }
    public void UpDatePassPillar()
    {
        _currentPillar = _pillarController.gameObject.transform.GetChild(0).GetComponent<Pillar>();
        _currentEnemy = _currentPillar.GetEnemy().GetComponent<EnemyController>();
        _currentEnemy.isCurrentEnemy = true;
        IsGameOver = false;
    }
    //public void LoadScenceAgain()
    //{
    //    _pillarController.ResetPillarController();
    //    _player.ResetPlayer();
    //    _camera.transform.position = new Vector3(0, 0, -10);
    //}
}
