using System.Collections;
using UnityEngine;

public class BackGroundStatic : Singleton<BackGroundStatic>
{
    public GameObject player;
    private Vector3 offset;
    private bool _isMove = false;
    [SerializeField] Vector3 _posBgStatic1;
    [SerializeField] Vector3 _posBgStatic2;
    protected override void Awake()
    {
        base.Awake();
    }
    private void OnEnable()
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
    public void LoadBackGroundStatic()
    {
        GameObject BgStatic1 = ObjectPooler._instance.SpawnFromPool("BgStatic1" + GameController._instance.idBg, _posBgStatic1, Quaternion.identity);
        GameObject BgStatic2 = ObjectPooler._instance.SpawnFromPool("BgStatic2" + GameController._instance.idBg, _posBgStatic2, Quaternion.identity);
        BgStatic1.transform.parent = transform;
        BgStatic2.transform.parent = transform;
    }
    public void ResetBgStatic()
    {
        GameObject BgStatic1 = transform.GetChild(0).gameObject;
        BgStatic1.SetActive(false);
        ObjectPooler._instance.AddElement("BgStatic1" + GameController._instance.idBg, BgStatic1);
        BgStatic1.transform.parent = ObjectPooler._instance.transform;

        GameObject BgStatic2 = transform.GetChild(0).gameObject;
        BgStatic2.SetActive(false);
        ObjectPooler._instance.AddElement("BgStatic2" + GameController._instance.idBg, BgStatic2);
        BgStatic2.transform.parent = ObjectPooler._instance.transform;

        transform.position = new Vector3(0f, 0f, 0f);
    }
}
