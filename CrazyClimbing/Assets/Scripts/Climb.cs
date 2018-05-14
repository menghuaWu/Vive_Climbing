using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour {

    public SteamVR_TrackedObject controller;

    [HideInInspector]
    public Vector3 prePos;

    [HideInInspector]
    public bool canGrip;//是否可以抓取

    // Use this for initialization
    void Start () {

        prePos = controller.transform.localPosition;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Grip"))
        {
            canGrip = true;
        }
    }

    private void OnTriggerExit()
    {
        canGrip = false;
    }
}
