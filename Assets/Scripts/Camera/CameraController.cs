using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public GameObject player;
    private Vector3 offset;

    public void GoToShop()
    {
        transform.position = new Vector3(44, 31, -10);
    }
    public void GoToHome()
    {
        transform.position = new Vector3(0, 0, -10);
    }
}
