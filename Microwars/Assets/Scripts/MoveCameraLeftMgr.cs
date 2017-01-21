using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveCameraLeftMgr : ButtonPressed
{
    public override void OnButtonPressed()
    {
        if (Camera.main.transform.position.x > maxPositionL.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x - offset * Time.deltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z);
        }
    }
}