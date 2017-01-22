using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public static GameManager instance;

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

    public void loseGame()
    {
        //Activar el Canvas de juego perdido
        //Sonar
        //Volver al Menu
        print("Has perdido, MENDRUGO");
    }
}
