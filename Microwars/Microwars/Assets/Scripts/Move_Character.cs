using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Character : MonoBehaviour {

    public GameObject[] pos;

    //entero paracontrolar donde se encuentra el personaje, 0 = entrando en la cocina
    public int estadoActual;

    public float speed;

    bool move;
    int toMove;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (move)
        {
            StartCoroutine("Move");
            
        }
        print("Estado del personaje"+ estadoActual);
	}

    public void moveCharacter(int pos)
    {
        toMove = pos;
        switch (pos)
        {
            case 1:
                print("Go to point 1");
                move = true;
                break;
            case 2:
                print("Go to point 2");
                move = true;
              
                break;
            case 3:
                print("Go to point 3");
                move = true;
                break;

            case 4:
                print("Go to point 4");
                move = true;
                break;

            case 5:
                print("Go to point 5");
                move = true;
                break;
            case 6:
                print("Go to point 6");
                move = true;
                break;
            case 7:
                print("Go to point 7");
                move = true;

                break;
            case 8:
                print("Go to point 8");
                move = true;
                break;
            case 9:
                print("Go to point 9");
                move = true;
                break;
            case 10:
                print("Go to point 10");
                move = true;
                break;
            case 11:
                print("Go to point 11");
                move = true;
                break;
            case 12:
                print("Go to point 12");
                move = true;

                break;
            case 13:
                print("Go to point 13");
                move = true;
                break;

            case 14:
                print("Go to point 14");
                move = true;
                break;

        }
    }

    IEnumerator Move()
    {

        float step = speed * Time.deltaTime;
        
        switch (toMove)
        {
            case 1: // Entrar en cocina
                transform.position = Vector3.MoveTowards(transform.position, pos[0].transform.position, step);
                if (transform.position.x == pos[0].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 2: // ir a por noodles
                transform.position = Vector3.MoveTowards(transform.position, pos[1].transform.position, step);
                if (transform.position.x == pos[1].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 3: // echar agua
                transform.position = Vector3.MoveTowards(transform.position, pos[2].transform.position, step);
                if (transform.position.x == pos[2].transform.position.x)
                {
                    move = false;
                }

                // TODO Lanzar animación
                yield return null;
                break;

             case 4: // Girar mesa 1
                transform.position = Vector3.MoveTowards(transform.position, pos[3].transform.position, step);
                if (transform.position.x == pos[3].transform.position.x)
                {
                    move = false;
                    pos[7].GetComponent<ChangePositionPlayer>().nextPos = 9;
                }

                // TODO Lanzar animación
                yield return null;
                break;

            case 5: // Girar mesa 2
                transform.position = Vector3.MoveTowards(transform.position, pos[4].transform.position, step);
                if (transform.position.x == pos[4].transform.position.x)
                {
                    move = false;
                }

                // TODO Lanzar animación final ir a por los noodles e irse o ir a por los noodlesy morir
                yield return null;
                break;
            case 6: // Micro
                GetComponent<SpriteRenderer>().sortingOrder = 3;    // Poner delante de la mesa
                pos[6].GetComponent<ChangePositionPlayer>().nextPos = 8;    // Cambiar a subir a mesa 1
                pos[7].GetComponent<ChangePositionPlayer>().nextPos = 9;    // Cambiar a ir a kárate
                transform.position = Vector3.MoveTowards(transform.position, pos[5].transform.position, step);
                if (transform.position.x == pos[5].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 7: // Mesa2
                transform.position = Vector3.MoveTowards(transform.position, pos[6].transform.position, step);
                if (transform.position.x == pos[6].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 8: // Mesa1
                GetComponent<SpriteRenderer>().sortingOrder = 1;    // Poner detrás de la mesa
                transform.position = Vector3.MoveTowards(transform.position, pos[7].transform.position, step);
                if (transform.position.x == pos[7].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 9: // Karate
                pos[9].GetComponent<ChangePositionPlayer>().nextPos = 11;    // Cambiar a bajar a mesa 2
                pos[10].GetComponent<ChangePositionPlayer>().nextPos = 12;    // Cambiar a ir a micro
                pos[11].GetComponent<ChangePositionPlayer>().nextPos = 13; // Cambiar a ir a Mesa 3
                transform.position = Vector3.MoveTowards(transform.position, pos[8].transform.position, step);
                if (transform.position.x == pos[8].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 10: // Mesa1
                transform.position = Vector3.MoveTowards(transform.position, pos[9].transform.position, step);

                if (transform.position.x == pos[9].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 11: // Mesa2
                transform.position = Vector3.MoveTowards(transform.position, pos[10].transform.position, step);
                if (transform.position.x == pos[10].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 12: // Micro
                GetComponent<SpriteRenderer>().sortingOrder = 3;    // Poner delante de la mesa
                transform.position = Vector3.MoveTowards(transform.position, pos[11].transform.position, step);
                if (transform.position.x == pos[11].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 13: // Mesa3
                transform.position = Vector3.MoveTowards(transform.position, pos[12].transform.position, step);
                if (transform.position.x == pos[12].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;
            case 14: // pirarse
                transform.position = Vector3.MoveTowards(transform.position, pos[13].transform.position, step);
                if (transform.position.x == pos[13].transform.position.x)
                {
                    move = false;
                }
                yield return null;
                break;

        }
    }

    public void checkInputOpenClose()
    {
        print("Checkeo el estado del personaje y el input realizado");

        if (estadoActual == 5)
        {

        }
    }

    }