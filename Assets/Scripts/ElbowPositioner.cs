using Fusion;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElbowPositioner : NetworkBehaviour
{
    [Networked] public float elbow_value { get; set; }
    [Networked] public float wrist_value { get; set; }

    private bool isRightHanded = true;

    // Start is called before the first frame update
    void Start()
    {
        elbow_value = 0;
        wrist_value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion wristRot;
        if (!isRightHanded)
        {
            wristRot = Quaternion.AngleAxis(-wrist_value, Vector3.right);
        }
        else
        {
            wristRot = Quaternion.AngleAxis(wrist_value, Vector3.right);
        }

        transform.rotation = Quaternion.Euler(0, -90, elbow_value);
        transform.rotation = transform.rotation * wristRot;
    }

    public void SetElbow(float angle, float wristAngle)
    {
        elbow_value = ((angle / 370) * 230) - 90;
        wrist_value = wristAngle/2;
    }

    public void SetRighthanded(bool value)
    {
        isRightHanded = value;
    }
}
