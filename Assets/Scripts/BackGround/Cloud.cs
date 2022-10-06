using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public bool IsFindPlayer = false;
    private PlayerController _player;
    void Start()
    {
        StartCoroutine(FindPlayer());
    }
    private void FixedUpdate()
    {
        if (IsFindPlayer)
        {
            if (!_player.isMove)
            {
                transform.position += transform.right * -0.3f * Time.deltaTime;
            }
        }
    }
    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.4f);
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        IsFindPlayer = true;
    }
}
