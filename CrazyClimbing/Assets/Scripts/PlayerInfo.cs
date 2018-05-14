using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInfo : MonoBehaviour {

    public SteamVR_TrackedObject controller;
    public bool player_synchronize = false;
    public bool canJump = false;
    public bool startToJump = false;
    public bool jumpSucceed = false;

    private void Awake()
    {
        
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {


      
	}

    private void FixedUpdate()
    {
        var Device = SteamVR_Controller.Input((int)controller.index);

        if (canJump && Device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            
            player_synchronize = true;//同步完成
            GetComponent<CamerAnimate>().enabled = true;//相機環繞動畫 打開
            Debug.Log("TouchPad!!");
        }
        if (startToJump && Device.GetPressDown(SteamVR_Controller.ButtonMask.Trigger))
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(0,100,-100),ForceMode.Acceleration);
            //transform.Translate(transform.forward * -5 * Time.deltaTime);
        }

       
    }
}
