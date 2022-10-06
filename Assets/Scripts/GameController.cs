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
    [SerializeField] GameObject _regionShop;

    private bool _canClick;
    private bool _isNextCol = false;
    private int _currentScore;
    private int _currentCoins;
    public bool isOnShop = false;
    public bool isPause = false;

    public int CountHeadShot = 0;
    private bool isShowGameOver = false;
    public bool IsFever = false;
    public bool isSoundRifleCock = false;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        _isNextCol = true;
    }
    public void SetupGame(GameObject Player)
    {
        _player = Player.GetComponent<PlayerController>();
        _currentEnemy = _pillarController.GetFristPillar().GetComponent<Pillar>().GetEnemy().GetComponent<EnemyController>();
        _currentEnemy.isCurrentEnemy = true;
    }
    public void Update()
    {
        CheckCanClick();

        if (_canClick == false)
        {
            return;
        }
        if(!isOnShop&&!_player.isMove)
        {
            if (Input.GetMouseButton(0) && !_player.isRotation && _isNextCol)
            {
                _player.RotateHead();
                _player.RotateWeapon();

                if (!isSoundRifleCock)
                {
                    EnableSoundRifleCock();
                    isSoundRifleCock = true;
                }
            }
            if (Input.GetMouseButtonUp(0) && !_player.isShoot && _isNextCol)
            {
                _isNextCol = false;
                _player.isShoot = true;
                _player.isRotation = true;
                _player.isRotateHead = false;
                _player.GetWeapon().ClearTrail();
                _player.WeaponShoot();
                SoundController._instance.OnPlayAudio(SoundType.cannon_fire);
            }
            if (_player.isShoot)
            {   
                if (IsGameOver&& !isShowGameOver)
                {
                    AlwaysPresent._instance.DisplayNoti("Miss");
                    isShowGameOver = true;
         
                }
                if (_currentEnemy._stateEnemy == EnemyController.StateEnemy.Die)
                {
                    _player.isShoot = false;
                    GamePlay._instance.CountScore();

                    UpdateNoti();
                    UpdatePlayer();

                    StartCoroutine(WaitTimePlayerMove());
                    StartCoroutine(WaitTimePlayerMoveToNextPillar());
                    StartCoroutine(WaitTimeAddItimetimeToPool());
                    StartCoroutine(WaitTimeAddBornPillar());

                    BackGroundDynamic._instance.isCrateBg = true;

                    WallController._instance.isCrateWall = true;
                    WallController._instance.BornNewWall();
                    WallController._instance.AddWallToObjectPool();
                    UpdateCurrentEnemy();
                }

                if (_player.statePlayer == PlayerController.StatePlayer.Die)
                {
                    _player.isShoot = false;
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
    IEnumerator WaitTimePlayerMove()
    {
        yield return new WaitForSeconds(0.2f);
        _player.MoveToNextPillar();
    }
    IEnumerator WaitTimePlayerMoveToNextPillar()
    {
        yield return new WaitForSeconds(0.4f);
        _isNextCol = true;
    }
    IEnumerator WaitTimeAddItimetimeToPool()
    {
        yield return new WaitForSeconds(0.35f);
        ItemManager._instance.AddCoinsToPool();
    }
    IEnumerator WaitTimeAddBornPillar()
    {
        yield return new WaitForSeconds(0.35f);
        _pillarController.BonrNextNewPillar();
    }

    public void UpdatePlayer()
    {
        _player.GetWeapon().ResetRotation();
        _player.target = NewPosPlayer();
        _player.isRotation = false;
    }
    public Vector3 NewPosPlayer()
    {
        return new Vector3(_pillarController.transform.GetChild(0).transform.position.x+Random.RandomRange(1f,2f), _player.transform.position.y, 0);
    }
    void UpdateCurrentEnemy()
    {   
        _currentPillar = _pillarController.gameObject.transform.GetChild(1).GetComponent<Pillar>();
        _currentEnemy = _currentPillar.GetEnemy().GetComponent<EnemyController>();
        _currentEnemy.isCurrentEnemy = true;
        IsGameOver = false;
    }
    public void CountScore()
    {
        if (_currentEnemy.isHitHead)
        {
            _currentScore += 2;
        }
        else
        {
            _currentScore += 1;
        }
    }
    public int GetCurrentScore()
    {
        return _currentScore;
    }
    public void CountCoins()
    {
        _currentCoins++;
    }
    public int GetCurrentCoins()
    {
        return _currentCoins;
    }
    public int AmountCoin()
    {
        int AmountCoins = 0;

        if (_currentEnemy.isHitHead)
        {
            AmountCoins = Random.RandomRange(7, 10);
        }
        else if (_currentEnemy.isHitBody)
        {
            AmountCoins = Random.RandomRange(4, 7);
        }
        else
        {
            AmountCoins = Random.RandomRange(2, 4);
        }
        return /*(_player.GetWeapon().isFiver)?AmountCoins*2:*/AmountCoins;
    }
    public void UpdateNoti()
    {
        _player.GetWeapon().isFiver = false;
        _player.GetWeapon().SetActiveFeverParticle(false);
        IsFever = false;
        if (_currentEnemy.isHitHead)
        {
            CountHeadShot++;
            AlwaysPresent._instance.DisplayNoti("HEADSHOT +2PTS");
            if (CountHeadShot==3)
            {
                AlwaysPresent._instance.DisplayNotiFeVer("FEVER");
                _player.GetWeapon().isFiver = true;
                _player.GetWeapon().SetActiveFeverParticle(true);
                IsFever = true;
                CountHeadShot = 0;
            }
        }
        else
        {
            AlwaysPresent._instance.DisplayNoti("+1PTS");
            CountHeadShot = 0;
        }
    }
    public float GetAmountCoins()
    {
        return _currentCoins;
    }
    public PlayerController Player()
    {
        return _player;
    }
    public void ResurrectPlayer()
    {
        IsGameOver = false;
        _currentEnemy.GetWeapon().ResetRotation();
        _currentEnemy.isCurrentEnemy = true;
        _player.isRotation = false;
        _isNextCol = true;
        _player.RecurrectPlayer();
    }
    public void SetActiveRegionShop(bool res)
    {
        _regionShop.SetActive(res);
    }
    public void UpdateCoins()
    {
        //_currentCoins = 10000;
      ///  DataPlayer.UpdateAmountCoins(_currentCoins);
    }
    public void LoadDataGame()
    {
        _pillarController.SetUpGame();
        WallController._instance.SetUp();
        BackGroundDynamic._instance.SetUp();
        BackGroundController._instance.LoadBackGround();
    }
    public void EnableSoundRifleCock()
    {
        SoundController._instance.OnPlayAudio(SoundType.rifle_cock);
    }

    //public void LoadScenceAgain()
    //{
    //    _pillarController.ResetPillarController();
    //    _player.ResetPlayer();
    //    _camera.transform.position = new Vector3(0, 0, -10);
    //}
}
