using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatusSaver
{
    private const string COMPLETE_STRING = "LEVEL_COMPLETE";
    public static void SaveCompleteLevel(LevelData level)
    {
        PlayerPrefs.SetInt(COMPLETE_STRING + level.Key, 1);
    }
    public static bool HaveCompleteLevel(LevelData level)
    {
        var b = (PlayerPrefs.HasKey(COMPLETE_STRING + level.Key));
        return (PlayerPrefs.HasKey(COMPLETE_STRING + level.Key));
    }
}
