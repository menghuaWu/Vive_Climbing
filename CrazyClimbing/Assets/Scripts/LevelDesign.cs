using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelDesign : MonoBehaviour {

    public GameObject[] AllLevel;
    

    private void Awake()
    {
       
    }

    public void LevelSwitch(string Level)
    {

        MatchStarAndTime.matchStarAndTime.SetLevel(Level);
        SceneManager.LoadScene(Level);
    }

    
}



