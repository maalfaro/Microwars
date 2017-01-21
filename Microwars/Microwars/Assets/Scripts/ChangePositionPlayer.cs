using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePositionPlayer : MonoBehaviour
{

    public int nextPos;
    public float speed;
    //Esta variable la utilizamos para saber el estado del personaje
    public Move_Character personaje;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (personaje.estadoActual == 0)
        {
            //Si esta fuera de la cocina, empieza entrando en la cocina
            personaje.moveCharacter(1);

            //Cambiamos el estado del personaje a 1 que es el inicial en la escena
            personaje.estadoActual = 1;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        print("EstadoActual antes de la colision "+ personaje.estadoActual);

        
        if (other.tag == "Player" && personaje.estadoActual == nextPos -1) {
            personaje.estadoActual = nextPos;
            //Estamos en la pos 1 vamos a la 2
            other.SendMessage("moveCharacter", nextPos);
           
        }
    }
}
