using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneManager : MonoBehaviour {

    public static MenuSceneManager instance;

    private GameObject controles;
    private GameObject canvas;

    void Awake()
    {
        //If we don't currently have a game control...
        if (instance == null)
            //...set this one to be it...
            instance = this;
        //...otherwise...
        else if (instance != this)
            //...destroy this one because it is a duplicate.
            // En realidad yo destruiría el otro y me quedaría con este
            Destroy(gameObject);
    }

    // Use this for initialization
    void Start () {
        controles = GameObject.FindGameObjectWithTag("Controles");
        if (controles)
        {
            controles.SetActive(false);
        }

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        canvas.SetActive(false);
	}

    public void ActivateCanvas()
    {
        canvas.SetActive(true);
        GameObject audioManager = GameObject.FindGameObjectWithTag("AudioManager");
        audioManager.GetComponent<AudioSource>().Play();
    }
}
