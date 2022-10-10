using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : BulletPlayer, Iflyable
{
	private SpriteRenderer sr;
	private Vector3 ori_scale;

	private bool isHit;

	[SerializeField] int _idBullet;
    private void OnEnable()
    {
		sr = GetComponent<SpriteRenderer>();
		ori_scale = base.transform.localScale;
		isHit = false;
	}
    private void FixedUpdate()
	{
		if (isHit)
		{
			if (sr.color.a > 0f)
			{
                if (base.transform.localScale.y > 0f)
                {
                    base.transform.localScale -= new Vector3(0f, ori_scale.y / 50f, 0f);
                }
                sr.color -= new Color(0f, 0f, 0f, 0.025f);
				if (sr.color.a <= 0f)
				{
					Renew();
				}
			}
		}
		else
		{
			base.transform.localScale += new Vector3(0.35f, 0f, 0f);
		}
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
			GetComponent<BoxCollider2D>().enabled = false;
        }
        base.transform.localScale = new Vector3(10f, base.transform.localScale.y, base.transform.localScale.z);
		isHit = true;
	}
	void Renew()
    {
		//sr.color = new Color(1f, 0f, 0f, 1f);
		sr.color = new Color(Random.RandomRange(0, 1f), Random.RandomRange(0, 1f), Random.RandomRange(0, 1f), 1f);
		base.transform.localScale = ori_scale;
		ObjectPooler._instance.AddElement("BulletPlayer" + _idBullet, gameObject);
		GetComponent<BoxCollider2D>().enabled = true;
		gameObject.SetActive(false);
	}

    public void Fly()
    {
      //  throw new System.NotImplementedException();
    }
}
