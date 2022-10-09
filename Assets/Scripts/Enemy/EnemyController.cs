using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    [SerializeField] Rigidbody2D _rigidbody2D;
    [SerializeField] float _force;
    [SerializeField] float _torqueSpeed;
    private WeaponEnemy _weapon;
    public bool isCurrentEnemy;
    public Vector3 _posEnemy;

    // Component Enemy
    [SerializeField] GameObject _head;
    [SerializeField] GameObject _body;
    [SerializeField] GameObject _feet;

    public bool isBornCoin;
    public bool isHitHead;
    public bool isHitBody;
    public bool isHitFeet;

    public GameObject player;
    public enum StateEnemy
    {
        Living,
        Die,
    }
    public StateEnemy _stateEnemy;
    void Start()
    {
        isHitHead = false;
        isHitBody = false;
        isHitFeet = false;
        isBornCoin = true;
        _weapon = Weapon.GetComponent<WeaponEnemy>();
    }
    private void Awake()
    {
        isCurrentEnemy = false;
    }
    private void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if(GameController._instance.isGameOver)
        {
            if(isCurrentEnemy)
            {
                if (GameController._instance.statePlayer != PlayerController.StatePlayer.Die && _stateEnemy != StateEnemy.Die)
                {
                    isCurrentEnemy = false;
                    Shoot();
                }
            }
        }
    }

   public void Die()
    {
        SoundController._instance.OnPlayAudio(SoundType.PassPillar);
        if (isBornCoin)
        {
            Vector3 PosCoin = new Vector3(_head.transform.position.x, _head.transform.position.y + 0.2f, 0f);
            gameObject.transform.parent.transform.parent.GetComponent<Pillar>().BornCoins(PosCoin);

            if (GameController._instance.isFever)
            {
                gameObject.transform.parent.transform.parent.GetComponent<Pillar>().BornDiamonds(PosCoin);
            }
            isBornCoin = false;
        }
        _stateEnemy = StateEnemy.Die;

        if (gameObject.GetComponent<Rigidbody2D>() == null)
        {
             AddRigibody();
            Vector3 VectorForce = new Vector3(Random.RandomRange(0.1f, 0.22f), Random.RandomRange(0.6f, 0.9f), 0);
            _rigidbody2D.AddForce(VectorForce * _force);
            _rigidbody2D.AddTorque(_torqueSpeed, ForceMode2D.Force);
            _head.GetComponent<PolygonCollider2D>().enabled = false;
            _body.GetComponent<BoxCollider2D>().enabled = false;
            _feet.GetComponent<BoxCollider2D>().enabled = false;
       }
       StartCoroutine(WaitTimeResetDie());
    }
    IEnumerator WaitTimeResetDie()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject.GetComponent<Rigidbody2D>());
    }
    public void AddRigibody()
    {
       _rigidbody2D = gameObject.AddComponent<Rigidbody2D>();
    }
    //public void RemoveRigibody()
    //{
    //    Destroy(gameObject.GetComponent<Rigidbody2D>());
    //}
    void WeaPonRotateToPlayer()
    {
        Vector3 VectorA = _weapon.PosFirePoint() -Weapon.transform.position;
        Vector3 VectorB = player.transform.position - Weapon.transform.position;
        float angle = Vector2.Angle(VectorA, VectorB);
        StartCoroutine(_weapon.FadeRotateToTarget(0, angle));
    }
    public Weapon GetWeapon()
    {
        return _weapon;
    }
  public void Shoot()
    {
        StartCoroutine(WaitTimeShoot());
    }
    IEnumerator WaitTimeShoot()
    {  
        WeaPonRotateToPlayer();
        yield return new WaitForSeconds(0.6f);
        _weapon.Shoot();
    }
    public void ResetEnemy()
    {
        isBornCoin = true;
        isCurrentEnemy = false;
        _weapon = Weapon.GetComponent<WeaponEnemy>();
        _stateEnemy = StateEnemy.Living;
        transform.localPosition = _posEnemy;
        transform.localRotation = Quaternion.identity;
        isCurrentEnemy = false;

        _head.SetActive(true);
        _head.GetComponent<PolygonCollider2D>().enabled = true;
        _body.GetComponent<BoxCollider2D>().enabled = true;
        _feet.GetComponent<BoxCollider2D>().enabled = true;

        _head.GetComponent<HeadEnemy>().SetActiveParticleBoolHead(false);
        _body.GetComponent<BodyEnemy>().SetActiveParticleBoolBody(false);
        _feet.GetComponent<FeetEnemy>().SetActiveParticleBoolFeetEnemy(false);

        isHitHead = false;
        isHitBody = false;
        isHitFeet = false;

    }
    public void ResetLocalRota()
    {
        transform.localRotation = Quaternion.identity;
    }
}
