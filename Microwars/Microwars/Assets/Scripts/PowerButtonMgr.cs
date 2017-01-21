using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class PowerButtonMgr : MonoBehaviour {

    public Sprite[] powerWheelSprites = new Sprite[6];
    private int counter = 1;

    public void Rotate()
    {
        GetComponent<Image>().sprite = powerWheelSprites[counter++];
        if (counter == powerWheelSprites.Length)
        {
            counter = 0;
        }
    }

}

enum PowerButtonTypes
{

    STATE_100=0, STATE_200 = 1, STATE_300 = 2, STATE_400 = 3, STATE_500 = 4, STATE_GRILL = 5
}
