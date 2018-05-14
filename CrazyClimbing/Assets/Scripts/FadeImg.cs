using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeImg : MonoBehaviour {

    public bool fadeEnd = false;

	// Use this for initialization
	void Start () {
        
    }

    private void OnEnable()
    {
        GetComponent<Animation>().Play("FadeImg");
        
    }

    // Update is called once per frame
    void Update () {



        if (GetComponent<Animation>().IsPlaying("FadeImg"))
        {
            fadeEnd = false;
        }
        else
        {
            fadeEnd = true;
        }
    }
}
