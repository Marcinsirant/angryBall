using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveStats
{
    public int[] stats;
    public string[] statsDate;
    public int coin;
    
    public List<int> ballsBought;
    public int nomberOfCurrentBall;
    public SaveStats(int[] saveStats, string[] saveStatsDate, int coin, List<int> ballsBought, int nomberOfCurrentBall)
    {
        stats = new int[4];
        statsDate = new string[4];
        stats = saveStats;
        statsDate = saveStatsDate;
        this.coin = coin;
        this.ballsBought = ballsBought;
        this.nomberOfCurrentBall = nomberOfCurrentBall;
    }
}
