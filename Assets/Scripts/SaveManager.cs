using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveManager
{
    const string UNLOCKED_LEVEL_KEY = "UnlockedLevel";
    const string SENSITIVITY_SLIDER_VALUE_KEY = "SensitivitySliderValue";
    
    const string CROSSHAIR_LENGTH_SLIDER_VALUE_KEY = "CrosshairLengthSliderValue";
    const string CROSSHAIR_WIDTH_SLIDER_VALUE_KEY = "CrosshairWidthSliderValue";
    const string CROSSHAIR_SPREAD_SLIDER_VALUE_KEY = "CrosshairSpreadSliderValue";
    
    const string CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY = "CrosshairScreenSpaceSizeDelta";
    const string CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY = "CrosshairScreenSpaceAnchoredPosition";
    
    const string CROSSHAIR_RED_SLIDER_VALUE_KEY = "CrosshairRedSliderValueKey";
    const string CROSSHAIR_GREEN_SLIDER_VALUE_KEY = "CrosshairGreenSliderValueKey";
    const string CROSSHAIR_BLUE_SLIDER_VALUE_KEY = "CrosshairBlueSliderValueKey";
    
    const string CROSSHAIR_SAVED_KEY = "CrosshairSaved";




    public static void UnlockNextLevel(int currentLevel)
    {       
        int unlocked = PlayerPrefs.GetInt(UNLOCKED_LEVEL_KEY, 0);
        if(currentLevel + 1 > unlocked)
        {
            PlayerPrefs.SetInt(UNLOCKED_LEVEL_KEY, currentLevel + 1);
            PlayerPrefs.Save();
        }
    }
    public static bool IsLevelUnlocked(int level)
    {
        int unlocked = PlayerPrefs.GetInt(UNLOCKED_LEVEL_KEY, 0);
        return level <= unlocked;
    }
    public static bool IsLevelUnlockedString(string level)
    {
        int unlocked = PlayerPrefs.GetInt(UNLOCKED_LEVEL_KEY, 0);
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
        if(level == "Challenge" || level == "Blitz" || level == "Blitz Easy" || level == "Blitz Medium" || level == "Blitz Hard")
        {
            return 4 <= unlocked;
        }
        // if(level == "freeplay")
        // {
        //     return 5 <= unlocked;
        // }
        return false;
    }
    public static void SaveSensitivity(float sensitivity)
    {
        PlayerPrefs.SetFloat(SENSITIVITY_SLIDER_VALUE_KEY, sensitivity);
    }
    public static void SaveCrosshairLengthSliderValue(float length)
    {
        PlayerPrefs.SetFloat(CROSSHAIR_LENGTH_SLIDER_VALUE_KEY, length);
    }
    public static void SaveCrosshairWidthSliderValue(float width)
    {
        PlayerPrefs.SetFloat(CROSSHAIR_WIDTH_SLIDER_VALUE_KEY, width);
    }
    public static void SaveCrosshairSpreadSliderValue(float spread)
    {
        PlayerPrefs.SetFloat(CROSSHAIR_SPREAD_SLIDER_VALUE_KEY, spread);
    }
    public static void SaveCrosshairRedValue(int red)
    {
        PlayerPrefs.SetInt(CROSSHAIR_RED_SLIDER_VALUE_KEY, red);
    }
    public static void SaveCrosshairGreenSliderValue(int green)
    {
        PlayerPrefs.SetInt(CROSSHAIR_GREEN_SLIDER_VALUE_KEY, green);
    }
    public static void SaveCrosshairBlueSliderValue(int blue)
    {
        PlayerPrefs.SetInt(CROSSHAIR_BLUE_SLIDER_VALUE_KEY, blue);
    }
    //public static void SaveScreenSpaceCrosshair(Vector2 sizeDelta, Vector2 anchoredPosition)
    //{
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_1_X", sizeDelta.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_1_Y", sizeDelta.y);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_2_X", sizeDelta.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_2_Y", sizeDelta.y);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_3_X", sizeDelta.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_3_Y", sizeDelta.y);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_4_X", sizeDelta.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY + "_4_Y", sizeDelta.y);

    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_1_X", anchoredPosition.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_1_Y", anchoredPosition.y);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_2_X", anchoredPosition.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_2_Y", anchoredPosition.y);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_3_X", anchoredPosition.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_3_Y", anchoredPosition.y);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_4_X", anchoredPosition.x);
    //    PlayerPrefs.SetFloat(CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY + "_4_Y", anchoredPosition.y);

    //}
    public static void SaveScreenSpaceCrosshairTick(string key, int i, Vector2 v)
    {
        PlayerPrefs.SetFloat($"{key}_{i}_x", v.x);
        PlayerPrefs.SetFloat($"{key}_{i}_y", v.y);
    }
    public static void SetSaved()
    {
        PlayerPrefs.SetString(CROSSHAIR_SAVED_KEY, "true");
    }

    public static float GetSensitivity()
    {
        return PlayerPrefs.GetFloat(SENSITIVITY_SLIDER_VALUE_KEY);
    }
    public static float GetCrosshairLength()
    {
        return PlayerPrefs.GetFloat(CROSSHAIR_LENGTH_SLIDER_VALUE_KEY);
    }
    public static float GetCrosshairWidth()
    {
        return PlayerPrefs.GetFloat(CROSSHAIR_WIDTH_SLIDER_VALUE_KEY);
    }
    public static float GetCrosshairSpread()
    {
        return PlayerPrefs.GetFloat(CROSSHAIR_SPREAD_SLIDER_VALUE_KEY);
    }
    public static Vector2 GetScreenSpaceCrosshairSizeDelta(int i)
    {
        float x = PlayerPrefs.GetFloat($"CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY_{i}_x");
        float y = PlayerPrefs.GetFloat($"CROSSHAIR_SCREEN_SPACE_SIZE_DELTA_KEY_{i}_y");

        return new Vector2(x, y);
    }
    public static Vector2 GetScreenSpaceCrosshairAnchoredPosition(int i)
    {
        float x = PlayerPrefs.GetFloat($"CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY_{i}_x");
        float y = PlayerPrefs.GetFloat($"CROSSHAIR_SCREEN_SPACE_ANCHORED_POSITION_KEY_{i}_y");

        return new Vector2(x, y);
    }
    public static int GetCrosshairRed()
    {
        return PlayerPrefs.GetInt(CROSSHAIR_RED_SLIDER_VALUE_KEY);
    }
    public static int GetCrosshairGreen()
    {
        return PlayerPrefs.GetInt(CROSSHAIR_GREEN_SLIDER_VALUE_KEY);
    }
    public static int GetCrosshairBlue()
    {
        return PlayerPrefs.GetInt(CROSSHAIR_BLUE_SLIDER_VALUE_KEY);
    }
    public static bool GetSaved()
    {
        if (PlayerPrefs.GetString(CROSSHAIR_SAVED_KEY) == "true")
        {
            return true;
        }
        return false;
    }

}
    