using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("EndPoint"))
        {
            gameObject.GetComponent<PlayerInfo>().jumpSucceed = true;
        }
    }
}
