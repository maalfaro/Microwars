using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButtonMgr : MonoBehaviour {

    public Sprite[] powerWheelSprites = new Sprite[6];
    public int counter = 1;

    public void Rotate()
    {
        GetComponent<Image>().sprite = powerWheelSprites[counter++];
        if (counter == powerWheelSprites.Length)
        {
            counter = 0;
        }
    }

}

