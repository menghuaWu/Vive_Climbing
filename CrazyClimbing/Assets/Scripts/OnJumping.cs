using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnJumping : MonoBehaviour {

    public static Vector3 oriVector;
    public static Quaternion oriRotate;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            oriVector = collision.gameObject.transform.position;
            oriRotate = collision.gameObject.transform.rotation;
            collision.gameObject.GetComponent<PlayerInfo>().canJump = true;
        }
    }
}
