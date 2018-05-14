using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserPointer : MonoBehaviour {

    public GameObject laserPrefab;
    private GameObject laser;
    private Transform laserTranasform;
    private Vector3 hitPoint;

    private SteamVR_TrackedObject trackedObject;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObject.index); }
    }

    private void Awake()
    {
        trackedObject = GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start () {
        laser = Instantiate(laserPrefab);
        laserTranasform = laser.transform;
	}
	
	// Update is called once per frame
	void Update () {

        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log("00000");
            RaycastHit hit;
            if (Physics.Raycast(trackedObject.transform.position, transform.forward, out hit, 100))
            {
                hitPoint = hit.point;
                ShowLaser(hit);
            }

        }
        else
        {
            laser.SetActive(false);
        }

	}

    private void ShowLaser(RaycastHit hit)
    {
        laser.SetActive(true);
        laserTranasform.position = Vector3.Lerp(trackedObject.transform.position, hitPoint, 5f);
        laserTranasform.LookAt(hitPoint);
        laserTranasform.localScale = new Vector3(laserTranasform.localScale.x, laserTranasform.localScale.y, hit.distance);
    }
}
