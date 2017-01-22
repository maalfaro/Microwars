using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointMgr : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("JuanD") || other.CompareTag("Marta") || other.CompareTag("Heznito"))
        {
            other.gameObject.SendMessage("goToNextState");
        }
    }




}
