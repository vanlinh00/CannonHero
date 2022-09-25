using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] GameObject Weapon;
    private Weapon _weapon;
    private bool _isRotation = false;
    private bool _isShoot = false;
    private Rigidbody2D _rbComponentPlayer;
    [SerializeField] GameObject[] _objectComponentPlayer;
    [SerializeField] float _torqueSpeed=1200f;
    [SerializeField] float _force = 300f;
    private void Start()
    {
        _weapon = Weapon.GetComponent<Weapon>();
    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && !_isRotation && _weapon.currentAngleZ <= 90f)
        {
            _weapon.AutoRotate();
        }
        if (Input.GetMouseButtonUp(0) && !_isShoot)
        {
            _isRotation = true;
            _isShoot = true;
            _weapon.Shoot();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Bullet"))
          {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            BreakObjectInPlayer();
            collision.gameObject.SetActive(false);
          }
    }
    public void BreakObjectInPlayer()
    {
        for (int i = 0; i < _objectComponentPlayer.Length; i++)
        {
            if (_objectComponentPlayer[i].GetComponent<Rigidbody2D>() == null)
            {
                _objectComponentPlayer[i].GetComponent<SpriteRenderer>().color= new Color(0, 0,0);
                _rbComponentPlayer = _objectComponentPlayer[i].gameObject.AddComponent<Rigidbody2D>();
            }
            _rbComponentPlayer.AddForce(new Vector3(Random.Range(-1f, 1f), Random.Range(0.5f, 1.2f), 0f) * _force);
            _rbComponentPlayer.AddTorque(_torqueSpeed, ForceMode2D.Force);
        }
    }

}
