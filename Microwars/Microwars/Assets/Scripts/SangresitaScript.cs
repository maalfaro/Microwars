using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SangresitaScript : MonoBehaviour {

    public void Blood()
    {
        StartCoroutine("Bleed");
    }

    
    IEnumerator Bleed()
    {
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sangresita1");
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sangresita2");
        yield return new WaitForSeconds(0.5f);
        GetComponent<Image>().sprite = Resources.Load<Sprite>("Images/Sangresita3");
        yield return new WaitForSeconds(2);
        enabled = false;
    }
}
