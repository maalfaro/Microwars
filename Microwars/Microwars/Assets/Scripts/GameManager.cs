using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public GameObject tePillaron;
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
        if (!JuanDCharacterMgr.DEAD ||  GameObject.FindGameObjectWithTag("JuanD").GetComponent<JuanDCharacterMgr>().state != 11)
        {
            tePillaron.SetActive(true);
            StartCoroutine("Loser");
        }
            //SceneManager.LoadScene(2);
    }

    IEnumerator Loser()
    {
        yield return new WaitForSeconds(2);
        //Cargar escena perder
        SceneManager.LoadScene("LoseScene");
    }
}
