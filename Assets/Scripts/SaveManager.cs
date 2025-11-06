using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    const string key = "UnlockedLevel";

    public static void UnlockNextLevel(int currentLevel)
    {
        int unlocked = PlayerPrefs.GetInt(key, 0);
        if(currentLevel + 1 > unlocked)
        {
            PlayerPrefs.SetInt(key, currentLevel + 1);
            PlayerPrefs.Save();
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        int unlocked = PlayerPrefs.GetInt(key, 0);
        return level <= unlocked;
    }
    public static bool IsLevelUnlockedString(string level)
    {
        int unlocked = PlayerPrefs.GetInt(key, 0);
        if(level == "Tutorial")
        {
            return true;
        }
        if(level == "Easy")
        {
            return 1 <= unlocked;
        }
        if(level == "Medium")
        {
            return 2 <= unlocked;
        }
        if(level == "Hard")
        {
            return 3 <= unlocked;
        }
        if(level == "Challenge")
        {
            return 4 <= unlocked;
        }
        // if(level == "freeplay")
        // {
        //     return 5 <= unlocked;
        // }
        return false;
    }
}
