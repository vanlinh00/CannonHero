﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPlayer
{
    private const string ALL_DATA = "all_data";
    private static InforPlayer inforPlayer;
    static DataPlayer()
    {
        inforPlayer = JsonUtility.FromJson<InforPlayer>(PlayerPrefs.GetString(ALL_DATA));
        if (inforPlayer == null)
        {
            inforPlayer = new InforPlayer
            {
                isLoadGameAgain = false,
                bestScore = 0,
                isOnAudio = true,
                listIdHero = new List<int>() { 1 },
                idHeroPlaying = 1,

            };
            SaveData();
        }
    }
    private static void SaveData()
    {
        var data = JsonUtility.ToJson(inforPlayer);
        PlayerPrefs.SetString(ALL_DATA, data);
    }
    public static void UpdataLoadGameAgain(bool IsLoadGameAgain)
    {
        inforPlayer.isLoadGameAgain = IsLoadGameAgain;
        SaveData();
    }
    public static void UpdateBestScore(int Score)
    {
        inforPlayer.bestScore = Score;
        SaveData();
    }
    public static void ChangeStateAudio(bool IsOnAudio)
    {
        inforPlayer.isOnAudio = IsOnAudio;
        SaveData();
    }
    public static void AddNewIdHero(int IdHero)
    {
        inforPlayer.listIdHero.Add(IdHero);
        SaveData();
    }
    public static void UpdateHeroPlaying(int IdHero)
    {
        inforPlayer.idHeroPlaying = IdHero;
        SaveData();
    }
    public static InforPlayer GetInforPlayer()
    {
        return inforPlayer;
    }
}
public class InforPlayer
{
    public bool isLoadGameAgain;
    public int bestScore;
    public bool isOnAudio;
    public List<int> listIdHero;
    public int idHeroPlaying;
}