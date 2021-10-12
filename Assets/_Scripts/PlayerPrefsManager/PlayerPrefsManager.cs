using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{

    /// <summary>
    /// 
    /// The player score data are in these variables:
    /// PLAYERPREFS_NAME, PLAYERPREFS_WORDHUNT, PLAYERPREFS_MATCHINGSHAPES, PLAYERPREFS_SPELLING
    /// all are in strings adding "     "(5 spaces if score is 0 to 9) and/or "    "(4 spaces if score is 10) score dependent
    /// 
    /// </summary>


    private void Start()
    {
        if (!PlayerPrefs.HasKey("PLAYERPREFS_NAME"))
        {
            PlayerPrefs.SetString("PLAYERPREFS_NAME", "");
        }

        if (!PlayerPrefs.HasKey("PLAYERPREFS_WORDHUNT"))
        {
            PlayerPrefs.SetString("PLAYERPREFS_WORDHUNT", "");
        }

        if (!PlayerPrefs.HasKey("PLAYERPREFS_MATCHINGSHAPES"))
        {
            PlayerPrefs.SetString("PLAYERPREFS_MATCHINGSHAPES", "");
        }

        if (!PlayerPrefs.HasKey("PLAYERPREFS_SPELLING"))
        {
            PlayerPrefs.SetString("PLAYERPREFS_SPELLING", "");
        }
    }

    public void AddScoreToMemory(string gameName, Stars starScriptObject)
    {
        string gameScore = starScriptObject.GetScoreStr()+ "  " + PlayerPrefs.GetString(gameName);
        PlayerPrefs.SetString(gameName, gameScore);
        Debug.Log("Score Got From Object: " + gameName + " = " + PlayerPrefs.GetString(gameName));
    }

    public void ClearScores()
    {
        PlayerPrefs.SetString("PLAYERPREFS_NAME", "");
        PlayerPrefs.SetString("PLAYERPREFS_WORDHUNT", "");
        PlayerPrefs.SetString("PLAYERPREFS_MATCHINGSHAPES", "");
        PlayerPrefs.SetString("PLAYERPREFS_SPELLING", "");
    }

    public string MatchingScore()
    {
        return PlayerPrefs.GetString("PLAYERPREFS_MATCHINGSHAPES");
    }

    public string WordHuntScore()
    {
        return PlayerPrefs.GetString("PLAYERPREFS_WORDHUNT");
    }

    public string NameScore()
    {
        return PlayerPrefs.GetString("PLAYERPREFS_NAME");
    }

    public string SpellingScore()
    {
        return PlayerPrefs.GetString("PLAYERPREFS_SPELLING");
    }


}
