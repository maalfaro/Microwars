using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerButtonMgr : MonoBehaviour {


    public void Rotate()
    {
        transform.localEulerAngles = transform.localEulerAngles - new Vector3(0, 0, 60);
    }

}
