using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {


    public string juan_1 = "¡Qué cansancio de tanto karate! Voy a hacer unos fideítos.";
    public string juan_2 = "Pondré los fideítos a baja potencia, que este microondas cierra muy fuerte a potencias altas.";
    public string juan_3 = "¡HYUAAAA!";
    public string juan_4 = "¡Ay, por fin! Al rico fideíto.";
    public string juan_5 = "Y ahora una partidita al MUERTE ONDAS. Que no es un juego tan malo.";
    public string juan_muerte = "¡¡¡Mis manos!!!";

    public Font fuente;
  
    private Text txtRef;
    // Use this for initialization
    void Start () {
        txtRef = GetComponent<Text>();

        txtRef.font = fuente;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void RemoveText()
    {
        txtRef.text = "";
    }

    public void setTextGui(int frase)
    {
        switch (frase)
        {
            case 0:
                txtRef.text = juan_1;
                break;
            case 1:
                txtRef.text = juan_2;
                break;
            case 2:
                txtRef.text = juan_3;
                break;
            case 3:
                txtRef.text = juan_4;
                break;
            case 4:
                txtRef.text = juan_5;
                break;
            case 5:
                txtRef.text = juan_muerte;
                break;
        }
    }
}
