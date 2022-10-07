using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public GameObject player;
    private Vector3 offset;
    private bool _isMove=false;
    public void SetUp(GameObject Player)
    {
        player = Player;
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        _isMove = true;
    }
    protected override void Awake()
    {
        base.Awake();
    }
    private void FixedUpdate()
    {
        if(_isMove &&!GameController._instance.isOnShop)
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, -10); 
        }
     
    }
    public void GoToShop()
    {
        transform.position = new Vector3(44, 31, -10);
    }
    public void GoToHome()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
