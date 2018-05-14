using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//顯示 Star //讀取本地資料庫
public class ShowStar : MonoBehaviour {

    public Image[] StartCount;
    public string StarLevel;

    private int star;

	// Use this for initialization
	void Start () {
        star = PlayerPrefs.GetInt(StarLevel);
        for (int i = 0; i < star; i++)
        {
            StartCount[i].gameObject.SetActive(true);
        }
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    
}
