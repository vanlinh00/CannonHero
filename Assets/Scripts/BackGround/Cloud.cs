using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float startX;
    public float limitX;
    public float startY;
    public float speed;
    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < limitX)
            transform.position = new Vector3(startX, Random.RandomRange(startY, startY + 1f), 0f);
    }
}
