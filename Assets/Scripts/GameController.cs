using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static PlayerController;

public class GameController : Singleton<GameController>
{
    [SerializeField] Pillar _currentPillar;
    [SerializeField] PlayerController _player;

    [SerializeField] EnemyController _currentEnemy;
    [SerializeField] PillarController _pillarController;

    public bool isGameOver = false;
    [SerializeField] GameObject _camera;
    [SerializeField] GameObject _regionShop;

    private bool _canClick;
    public bool isNextCol = false;
    private int _currentScore;
    public bool isOnShop = false;
   public bool isPause = false;

    public int CountHeadShot = 0;
    private bool isShowGameOver = false;
    public bool isFever = false;
    public bool isSoundRifleCock = false;

    public int idHeroPlaying;
    public int idBg;

    public StatePlayer statePlayer;

    [SerializeField] GameObject BackGrounds;
    public bool isMove;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        isNextCol = true;
        idHeroPlaying = DataPlayer.GetInforPlayer().idHeroPlaying;
    }
    public void SetupPlayer(GameObject Player)
    {
        _player = Player.GetComponent<PlayerController>();
      
    }
    public void SetUpEnemy()
    {
        _currentEnemy = _pillarController.GetFristPillar().GetComponent<Pillar>().GetEnemy().GetComponent<EnemyController>();
        _currentEnemy.isCurrentEnemy = true;
    }

    public void Update()
    {
        CheckCanClick();
        if (_canClick == false)
        {
            if(_player !=null&& _player.isShoot)
            {

            }
            else
            {
                return;
            }
        
        }
        if (!isOnShop&& !isPause)
            {
                if (Input.GetMouseButton(0) && !_player.isRotation && isNextCol)
                {
                    _player.RotateHead();
                    _player.RotateWeapon();

                    if (!isSoundRifleCock)
                    {
                        EnableSoundRifleCock();
                        isSoundRifleCock = true;
                    }
                }
                if (Input.GetMouseButtonUp(0) && !_player.isShoot && isNextCol)
                {
                    isNextCol = false;
                    _player.isShoot = true;
                    _player.isRotation = true;
                    _player.isRotateHead = false;
                    _player.GetWeapon().ClearTrail();
                    _player.WeaponShoot();
                }

                if (_player.isShoot)
                {
                    if (isGameOver && !isShowGameOver)
                    {
                        AlwaysPresent._instance.DisplayNoti("MISS");
                        isShowGameOver = true;
                    }
                    if (_currentEnemy._stateEnemy == EnemyController.StateEnemy.Die)
                    {
                        _player.StateRun();
                        _player.isShoot = false;
                        GamePlay._instance.CountScore();
                        UpdateNoti();
                        UpdatePlayer();
                        _pillarController.MoveToTarget();
                        UpdateCurrentEnemy(1);
                    }
                    if (_player.statePlayer == PlayerController.StatePlayer.Die)
                    {
                        _player.isShoot = false;
                        StartCoroutine(UiController._instance.FadeDisPlayGameOver());
                    }
                }
        }
    }
    public void Test()
    {
        if (_player.isShoot)
        {
            if (isGameOver && !isShowGameOver)
            {
                AlwaysPresent._instance.DisplayNoti("MISS");
                isShowGameOver = true;
            }
            if (_currentEnemy._stateEnemy == EnemyController.StateEnemy.Die)
            {
                _player.StateRun();
                _player.isShoot = false;
                GamePlay._instance.CountScore();
                UpdateNoti();
                UpdatePlayer();
                _pillarController.MoveToTarget();
                UpdateCurrentEnemy(1);
            }
            if (_player.statePlayer == PlayerController.StatePlayer.Die)
            {
                _player.isShoot = false;
                StartCoroutine(UiController._instance.FadeDisPlayGameOver());
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
    public void PassNextPillar()
    {
        isNextCol = true;
        isMove = false;
        SoundController2._instance.audioFx.loop = false;
        _player.GetWeapon().SetEnableTrail();
        _player.StateIdle();
        ItemManager._instance.AddCoinsToPool();
        ItemManager._instance.AddDiamondToPool();
    }

    public void UpdatePlayer()
    {
        _player.GetWeapon().ResetRotation();
        _player.isRotation = false;
      
    }

    void UpdateCurrentEnemy(int NumberPillar)
    {   
        _currentPillar = _pillarController.gameObject.transform.GetChild(NumberPillar).GetComponent<Pillar>();
        _currentEnemy = _currentPillar.GetEnemy().GetComponent<EnemyController>();
        _currentEnemy.isCurrentEnemy = true;
        isGameOver = false;
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
        int newAmountCoins = DataPlayer.GetInforPlayer().countCoins;
        DataPlayer.UpdateAmountCoins(newAmountCoins + 1);
    }
    public int GetCurrentCoins()
    {
        return DataPlayer.GetInforPlayer().countCoins;
    }
    public int AmountCoin()
    {
        int AmountCoins = 0;

        if (_currentEnemy.isHitHead)
        {
            AmountCoins = Random.RandomRange(4,6);
        }
        else if (_currentEnemy.isHitBody)
        {
            AmountCoins = Random.RandomRange(2, 4);
        }
        else
        {
            AmountCoins = Random.RandomRange(1, 3);
        }
        return (_player.GetWeapon().isFiver)? AmountCoins *2: AmountCoins;
    }
    public void UpdateNoti()
    {
        _player.GetWeapon().isFiver = false;
        _player.GetWeapon().ResetRotationFever();
        _player.GetWeapon().SetActiveBigFeverParticle(false);
        _player.GetWeapon().SetActiveSmallFeverParticle(false);
        isFever = false;
        if (_currentEnemy.isHitHead)
        {
            CountHeadShot++;
            AlwaysPresent._instance.DisplayNoti("HEADSHOT +2PTS");
            if(CountHeadShot==2)
            {
                _player.GetWeapon().SetActiveSmallFeverParticle(true);
            }
            if (CountHeadShot==3)
            {
                AlwaysPresent._instance.DisplayNotiFeVer("FEVER");
                _player.GetWeapon().isFiver = true;
                _player.GetWeapon().SetActiveBigFeverParticle(true);
                isFever = true;
                CountHeadShot = 0;
            }
        }
        else
        {
            AlwaysPresent._instance.DisplayNoti("+1PTS");
            CountHeadShot = 0;
        }
    }
    public PlayerController Player()
    {
        return _player;
    }
    public void ResurrectPlayer()
    {
        if(10<=DataPlayer.GetInforPlayer().countCoins)
        {
            isGameOver = false;
            _currentEnemy.GetWeapon().ResetRotation();
            _currentEnemy.isCurrentEnemy = true;
            _player.isRotation = false;
            isNextCol = true;
            _player.RecurrectPlayer();
            UiController._instance.OpenGamePlay();
            DataPlayer.UpdateAmountCoins(DataPlayer.GetInforPlayer().countCoins - 10);
        }
        AlwaysPresent._instance.CoinOfplayer().DisPlayAmountCoins();
    }
    public void SetActiveRegionShop(bool res)
    {
        _regionShop.SetActive(res);
    }

  
    public void EnableSoundRifleCock()
    {
        SoundController._instance.OnPlayAudio(SoundType.rifle_cock);
    }

    public void LoadScenceAgain()
    {
        OldObjectPool._instance.SettDisableAllObject();
        _pillarController.ResetPillarController();
        WallController._instance.ResetAllWalls();
        BackGrounds.GetComponent<BackGrounds>().ResetBg();
        CameraController._instance.transform.position = new Vector3(0, 0, -10f);
        _player.RecurrectPlayer();
        _player.transform.position = _player.startPos;
         isGameOver = false;
        _player.isRotation = false;
        isNextCol = true;
        isShowGameOver = false;

        ResetScore();
        ResFever();
        LoadData._instance.LoadDataGame();
        UpdateCurrentEnemy(0);
    }

    public void ResetScore()
    {
        _currentScore = 0;
    }
    public void ResFever()
    {
        CountHeadShot = 0;
        isFever = false;
        _player.GetWeapon().isFiver = false;
    }
}
