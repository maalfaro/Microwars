using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    private static AudioManager _audioManager;

    private AudioManager()
    {

    }

    public static AudioManager Instance
    {
        get
        {
            if (_audioManager == null)
                _audioManager = new AudioManager();
            return _audioManager;
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Katas()
    {
        
    }
}
