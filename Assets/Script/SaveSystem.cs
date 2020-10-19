using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem 
{
    public static void SaveDataPlayer(int[] saveStats, string[] saveStatsDate,int coin,List<int> ballsBought, int nomberOfCurrentBall)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.properties";
        FileStream stream = new FileStream(path, FileMode.Create);
        
        SaveStats data = new SaveStats(saveStats,saveStatsDate,coin,ballsBought,nomberOfCurrentBall);
        formatter.Serialize(stream, data);
        
        stream.Close();
    }

    public static SaveStats LoadDataPlayer()
    {
        string path = Application.persistentDataPath + "/player.properties";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream= new FileStream(path, FileMode.Open);

            SaveStats data = formatter.Deserialize(stream) as SaveStats;
            stream.Close();
            return data;
        }
        else
        {
            Debug.Log("null data");
            return null;
        }
    }
}