using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    

    public GameObject Player;
    public Text timeTxt;
    public Image fademessage;
    public int time;

    private int maxTime;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Use this for initialization
    void Start () {
        maxTime = 60 * 5;
        
        StartCoroutine(CountDown());
	}
	
	// Update is called once per frame
	void Update () {

        if (time == maxTime)
        {
            
            StopCoroutine(CountDown());
            timeTxt.text = "Times Up!";
        }

        if (Player.GetComponent<PlayerInfo>().jumpSucceed == false)
        {
            fademessage.GetComponent<FadeImg>().enabled = false;
        }
        else
        {
            MatchStarAndTime.matchStarAndTime.SetTime(maxTime, time);
            fademessage.GetComponent<FadeImg>().enabled = true;
        }

        if (fademessage.GetComponent<FadeImg>().fadeEnd)
        {
            SceneManager.LoadScene("Menu");
        }
        
	}

    IEnumerator CountDown()
    {
        while (time < maxTime && Player.GetComponent<PlayerInfo>().jumpSucceed == false)
        {
            time++;
            timeTxt.text = time + "";
            yield return new WaitForSeconds(1);
        }
    }
}
