using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameController : Singleton<GameController>
{
    [SerializeField] Pillar _currentPillar;
    [SerializeField] PlayerController _player;

    [SerializeField] EnemyController _currentEnemy;
    [SerializeField] PillarController _pillarController;

    public bool IsGameOver = false;
    [SerializeField] GameObject _camera;
    private bool _canClick;
    private bool _isNextCol = false;
    private int _currentScore;
    private int _currentCoins;
    public bool isOnShop = false;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
           _isNextCol = true;
           _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }
    private void Update()
    {
        CheckCanClick();

        if (_canClick == false)
        {
            return;
        }
        if(!isOnShop)
        {
            if (Input.GetMouseButton(0) && !_player.isRotation && _isNextCol)
            {
                _player.RotateHead();
                _player.RotateWeapon();
            }
            if (Input.GetMouseButtonUp(0) && !_player.isShoot && _isNextCol)
            {
                _isNextCol = false;
                _player.isShoot = true;
                _player.WeaponShoot();
                _player.isRotation = true;
                _player.isRotateHead = false;
                UpDatePassPillar();
            }

            if (_player.isShoot)
            {
                if (_currentEnemy._stateEnemy == EnemyController.StateEnemy.Die)
                {
                    _player.isShoot = false;
                    AlwaysPresent._instance.CountCoins();
                    GamePlay._instance.CountScore();
                    StartCoroutine(PassPillar());
                }
                if (_player.statePlayer == PlayerController.StatePlayer.Die)
                {
                    StartCoroutine(UiController._instance.FadeDisPlayGameOver());
                }
            }
        }
    }
    void CheckCanClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                _canClick = false;
            }
            else
            {
                _canClick = true;
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                _canClick = false;
            }
            else
            {
                _canClick = true;
            }
        }
    }
  
    IEnumerator PassPillar()
    {
        yield return new WaitForSeconds(0.9f);
        _player.GetWeapon().ResetRotation();
        // Pillar run
        _pillarController.MoveToTarget();

        // Play run
        StartCoroutine(_player.Run());
        yield return new WaitForSeconds(_player.GetTimeSpeed()*2);
    

        _pillarController.BonrNextNewPillar();
        _player.isRotation = false;
        _isNextCol = true;


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
    public void CountScore()
    {
        _currentScore++;
    }
    public float GetCurrentScore()
    {
        return _currentScore;
    }
    public void CountCoins()
    {
        _currentCoins += AmountCoin();
    }
    public int AmountCoin()
    {
        int AmountCoins = 0;
        if (_currentEnemy.isHitHead)
        {
            AmountCoins = 7;
        }
        else if (_currentEnemy.isHitBody)
        {
            AmountCoins = 4;
        }
        else
        {
            AmountCoins = 3;
        }
        return AmountCoins;
    }
    public float GetAmountCoins()
    {
        return _currentCoins;
    }
    //public void LoadScenceAgain()
    //{
    //    _pillarController.ResetPillarController();
    //    _player.ResetPlayer();
    //    _camera.transform.position = new Vector3(0, 0, -10);
    //}
}
