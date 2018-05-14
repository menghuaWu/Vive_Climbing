using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour {

    public GameObject player;
    public float fallThreshold = 5f;
    private GripManager gm;

    private void OnCollisionEnter(Collision collision)
    {
        gm = player.GetComponent<GripManager>();

        if (gm.startedClimbing && gm.canFall)
        {
            gm.startedClimbing = false;
            gm.canFall = false;
        }
    }
}
