using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchStarAndTime : MonoBehaviour {

    

    int star;
    string currentLevel;
    public static MatchStarAndTime matchStarAndTime;
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        matchStarAndTime = this;
    }


    public void SetTime(int tatalTime, int currentTime)
    {
        if (currentTime <= (tatalTime / 3))
        {
            star = 3;
            PlayerPrefs.SetInt(currentLevel, star);
            PlayerPrefs.Save();
        }
        else if (currentTime <= (tatalTime/2))
        {
            star = 2;
            PlayerPrefs.SetInt(currentLevel, star);
            PlayerPrefs.Save();
        }
        else if (currentTime <= (tatalTime - 1))
        {
            star = 1;
            PlayerPrefs.SetInt(currentLevel, star);
            PlayerPrefs.Save();
        }
        else
        {
            star = 0;
        }
    }

    public void SetLevel(string level)
    {
        currentLevel = level;
    }
}
