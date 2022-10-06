using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFlatfrom : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset;
    private bool _isMove = false;

    private void Start()
    {
        StartCoroutine(WaitTimeLoadPlayer());
    }
    IEnumerator WaitTimeLoadPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        player = GameObject.FindGameObjectWithTag("Player");
        offset.x = transform.position.x - player.transform.position.x;
        offset.y = transform.position.y - player.transform.position.y;
        _isMove = true;
    }
    private void FixedUpdate()
    {
        if (_isMove)
        {
            transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, 0);
        }

    }
}
