using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerAnimate : MonoBehaviour {

    public GameObject circleTarget;
    public float radius;
    public float circleSpeed;

    private float moveTime;
    private Vector3 cameraPos;
    private float number;
    public bool move = false;

	// Use this for initialization
	void Start () {
        enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
        
        if (gameObject.GetComponent<PlayerInfo>().player_synchronize)
        {
            cameraPos.y = circleTarget.transform.position.y;
            transform.position = cameraPos;
            move = true;
            moveTime += Time.deltaTime;
            if (move && moveTime <=18)
            {

                //做點別的事情來代替運鏡
                number += Time.deltaTime * circleSpeed * 0.1f;
                cameraPos.x = radius * Mathf.Cos(-number);
                cameraPos.z = radius * Mathf.Sin(-number);
                transform.position = cameraPos;
                transform.LookAt(circleTarget.transform.position);
            }
            if (moveTime > 18)
            {

                move = false;
                gameObject.GetComponent<PlayerInfo>().player_synchronize = false;
                transform.position = OnJumping.oriVector;
                transform.rotation = OnJumping.oriRotate;
                gameObject.GetComponent<PlayerInfo>().startToJump = true;
                enabled = false;
            }


            
        }


    }

    

}
