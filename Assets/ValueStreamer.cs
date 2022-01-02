using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Udp;

public class ValueStreamer : MonoBehaviour
{
    public UdpHost udpHost;

    public bool congruent = true;
    public bool doesMovement = true;

    private string x;
    private string z;
    private float xAngle;
    private float zAngle;

    private int defaultX = 315;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (doesMovement) {
            if (congruent) {
                xAngle = gameObject.transform.localEulerAngles.x;
                //xAngle = (xAngle > 0) ? xAngle - 360 : xAngle;
                x = xAngle.ToString("0.00");

                zAngle = gameObject.transform.localEulerAngles.z;
                zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;
                z = zAngle.ToString("0.00");
            } else {

                xAngle = gameObject.transform.localEulerAngles.x;
                //xAngle = (xAngle > 0) ? xAngle - 360 : xAngle;
                xAngle = defaultX - (xAngle - defaultX);
                x = (xAngle).ToString("0.00");

                zAngle = gameObject.transform.localEulerAngles.z;
                zAngle = (zAngle > 180) ? zAngle - 360 : zAngle;
                z = (-zAngle).ToString("0.00");
            }
        }
       
        //udpHost.SendMsg("x;" + x);
        //udpHost.SendMsg("z;" + z);

        // TODO: Send timestamp too
    }
}
