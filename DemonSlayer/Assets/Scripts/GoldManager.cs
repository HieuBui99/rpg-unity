using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GoldManager
{
    public static void SaveGold(int value)
    {
        PlayerPrefs.SetInt("Gold", value);
    }
    
    public static int GetGold()
    {
        if (PlayerPrefs.HasKey("Gold"))
        {
            return PlayerPrefs.GetInt("Gold");
        }
        else
        {
            return 0;
        }
    }

    public static void ResetGold()
    {
        PlayerPrefs.DeleteKey("Gold");
    }
}
