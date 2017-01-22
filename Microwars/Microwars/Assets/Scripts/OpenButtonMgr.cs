using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenButtonMgr : MonoBehaviour {

    [SerializeField]
    private GameObject backgroundMicroWave;
    private bool isVisible = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowBackground()
    {
        backgroundMicroWave.SetActive(isVisible = !isVisible);
    }
}
