using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public bool IsFindPlayer = false;
   
    private void FixedUpdate()
    {
        if (IsFindPlayer)
        {
            if (!GameController._instance.isPlayMove)
            {
                transform.position += transform.right * -0.3f * Time.deltaTime;
            }
        }
    }
    public void OnEnable()
    {
        StartCoroutine(FindPlayer());
    }
    IEnumerator FindPlayer()
    {
        yield return new WaitForSeconds(0.4f);
        IsFindPlayer = true;
    }

}
