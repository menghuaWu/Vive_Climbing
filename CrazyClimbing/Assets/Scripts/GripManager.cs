using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripManager : MonoBehaviour {

    public Rigidbody Body;//CameraRig

    public Climb left;//左手
    public Climb right;//右手

    public float velocityMutiplyie = 1.5f;//攀爬移動速度
    public bool isGripped;//是否抓住東西
    public bool startedClimbing;//開始攀爬
    public bool canFall;//是否可以墜落
    public float fallThreshold = 0;

    // Use this for initialization
    void Start () {

        isGripped = false;
        canFall = false;

        fallThreshold = fallThreshold + Body.transform.position.y;//身體距離地面距離

    }

    private void FixedUpdate()
    {
        var lDevice = SteamVR_Controller.Input((int)left.controller.index);//取得左手遙控器回傳值
        var rDevice = SteamVR_Controller.Input((int)right.controller.index);//取得右手遙控器回傳值

        isGripped = left.canGrip || right.canGrip;//取得左手或是右手controller狀態是否有抓住東西

        if (isGripped)//如果某一支遙控器正在抓東西
        {
            startedClimbing = true;//開始攀爬

            if (Body.transform.position.y > fallThreshold)
            {
                canFall = true;
            }

            if (left.canGrip && lDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger))//如果左手正在抓取東西，並且遙控器回值為正在按Trigger鍵
            {
                Body.useGravity = false;//身體無重力
                Body.isKinematic = true;//不受外力影響
                Body.transform.position += (left.prePos - left.transform.localPosition);
            }
            else if (left.canGrip && lDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))//抓取物體時，放開Trigger按鍵
            {
                Body.useGravity = true;//身體恢復重力，並往下掉落
                Body.isKinematic = false;//開始會受外力影響
                Body.velocity = ((left.prePos - left.transform.localPosition) * velocityMutiplyie) / Time.deltaTime;
            }

            if (right.canGrip && rDevice.GetPress(SteamVR_Controller.ButtonMask.Trigger))//如果右手正在抓取東西，並且遙控器回值為正在按Trigger鍵
            {
                Body.useGravity = false;//身體無重力
                Body.isKinematic = true;//不受外力影響
                Body.transform.position += (right.prePos - right.transform.localPosition);
            }
            else if (right.canGrip && rDevice.GetPressUp(SteamVR_Controller.ButtonMask.Trigger))//抓取物體時，放開Trigger按鍵
            {
                Body.useGravity = true;//身體恢復重力，並往下掉落
                Body.isKinematic = false;//開始會受外力影響
                Body.velocity = ((right.prePos - right.transform.localPosition) * velocityMutiplyie) / Time.deltaTime;
            }
        }
        else
        {
            Body.useGravity = true;
            Body.isKinematic = false;
        }

        left.prePos = left.transform.localPosition;
        right.prePos = right.transform.localPosition;
    }
}
