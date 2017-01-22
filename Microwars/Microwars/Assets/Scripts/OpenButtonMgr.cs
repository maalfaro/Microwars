using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButtonMgr : MonoBehaviour {

    public GameObject backgroundMicroWave;
    public bool isVisible = true;
    public PowerButtonMgr powerButtonMgr;
    public SangresitaScript sangresitaScript;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowBackground()
    {
        if (!isVisible)
        {
            if (GameObject.FindGameObjectWithTag("JuanD") != null)
            {
                if (GameObject.FindGameObjectWithTag("JuanD").GetComponent<JuanDCharacterMgr>().state == 11)
                {
                    if (powerButtonMgr.counter == 0)
                    {
                        JuanDCharacterMgr.DEAD = true;
                        sangresitaScript.enabled = true;
                        sangresitaScript.Blood();
                        GameObject.FindGameObjectWithTag("JuanD").GetComponent<JuanDCharacterMgr>().PlayMuerte();
                        GameObject.FindGameObjectWithTag("JuanD").GetComponent<JuanDCharacterMgr>().Muerte();
                    }
                    
                }
            }
        }

        if (isVisible) {
            if (GameObject.FindGameObjectWithTag("Marta") != null)
            {
                if (GameObject.FindGameObjectWithTag("Marta").GetComponent<MartaCharacterMgr>().state == 5)
                {
                        MartaCharacterMgr.DEAD = true;
                        sangresitaScript.enabled = true;
                        GameObject.FindGameObjectWithTag("Marta").GetComponent<MartaCharacterMgr>().PlayMuerte();
                        GameObject.FindGameObjectWithTag("Marta").GetComponent<MartaCharacterMgr>().Muerte();
                        StartCoroutine("Blood");
                }
            }
        }
        backgroundMicroWave.SetActive(isVisible = !isVisible);
    }

    IEnumerator Blood()
    {
        yield return new WaitForSeconds(2.5f);
        sangresitaScript.Blood();
    }
}
