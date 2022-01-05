using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SavingSystem : MonoBehaviour
{

    public static readonly string path = Application.dataPath + "/saves/";



    public static void Save(string saveID)
    {
        File.WriteAllText(path + "/leaderboard.txt", saveID);
    }

    public static string Load()
    {
        if (File.Exists(path + "/leaderboard.txt"))
        {
            string save = File.ReadAllText(path + "/leaderboard.txt");
            return save;
        }else
        {
            return null;
        }
    }

}
