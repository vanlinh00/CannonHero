using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionShop : Singleton<RegionShop>
{
    [SerializeField] GameObject _positionAllHeroSelect;
    [SerializeField] GameObject _currentHeroLoading;
    protected override void Awake()
    {
        LoadAllHero();
        base.Awake();
    }
    private void OnEnable()
    {
        StartCoroutine(WaitLoadListHero());
    }
    IEnumerator WaitLoadListHero()
    {
        yield return new WaitForSeconds(0.1f);
        _currentHeroLoading = _positionAllHeroSelect.transform.GetChild(DataPlayer.GetInforPlayer().idHeroPlaying-1).gameObject;
        DisableNotHeros();
        LoadHero(DataPlayer.GetInforPlayer().idHeroPlaying);
    }
    public void LoadAllHero()
    {
        for(int i=1;i<=10;i++)
        {
            GameObject Player = Instantiate(Resources.Load("ShopHero/Hero" + i, typeof(GameObject)), new Vector3(0,0,0), Quaternion.identity) as GameObject;
            Player.SetActive(false);    
            Player.transform.parent = _positionAllHeroSelect.transform;
            Player.transform.localPosition = new Vector3(0, 0, 0);
        }
    }
    public void LoadHero(int IdHero)
    {
        _currentHeroLoading.SetActive(false);
           _currentHeroLoading = _positionAllHeroSelect.transform.GetChild(IdHero - 1).gameObject;
        _currentHeroLoading.SetActive(true);
    }
    public void DisableNotHeros()
    {
        int children = _positionAllHeroSelect.transform.childCount;
        for (int i = 0; i < children; ++i)
        {
           _positionAllHeroSelect.transform.GetChild(i).gameObject.SetActive(false);
        }
    }

}
