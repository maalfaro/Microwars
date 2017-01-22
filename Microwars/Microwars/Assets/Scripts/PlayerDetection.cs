using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetection : MonoBehaviour {

    public int patience = 100;
    public bool detected = false;
    public int lossMultiplier = 1;  // Para el enfriamiento de las habilidades (spamear hace ser detectado)
    public int cooldown = 5;

    private GameObject eye;
    private bool lastDetectedValue = false;

    private void Start()
    {
        eye = GameObject.FindGameObjectWithTag("Eye");
    }

    private void Update()
    {
        // Para no actualizar la variable todo el puto rato, sino sólo cuando cambia
        if (detected != lastDetectedValue){
            eye.GetComponent<EyeLogic>().opened = detected;
            lastDetectedValue = detected;
        }
    }

    // LLamar a esto al utilizar el interfaz
    void msg_microwaveActing(int loss){
        if (detected) {
            //El jugador pierde
            GameManager.instance.loseGame();
        } else {
            // Se pierden puntos de paciencia
            int totalLoss = lossMultiplier * loss;
            patience = patience - totalLoss;
            if (patience < 0)
            {
                // El jugador pierde
                GameManager.instance.loseGame();
            }
            else
            {
                // Incrementamos el multiplicador y cuando pase el enfriamiento lo decrementamos
                lossMultiplier++;
                StartCoroutine("decrementLoss");
            }
        }
    }

    IEnumerator decrementLoss()
    {
        yield return new WaitForSeconds(5f);
        lossMultiplier--;
    }

}
