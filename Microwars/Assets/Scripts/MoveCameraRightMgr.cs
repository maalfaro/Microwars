using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MoveCameraRightMgr : MoveCameraMgr
{
    public override void moveCamera()
    {

        if (Camera.main.transform.position.x < maxPositionR.transform.position.x)
        {
            Camera.main.transform.position = new Vector3(Camera.main.transform.position.x+offset * Time.deltaTime, Camera.main.transform.position.y, Camera.main.transform.position.z) ;
        }
    }
}