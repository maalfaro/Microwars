using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerDetection : MonoBehaviour {

    public int patience = 100;
    public bool detected = false;
    public int lossMultiplier = 1;  // Para el enfriamiento de las habilidades (spamear hace ser detectado)
    public int cooldown = 5;

    // LLamar a esto al utilizar el interfaz
    void microwaveActing(int loss){
        if (detected) {
            //El jugador pierde
        } else {
            // Se pierden puntos de paciencia
            int totalLoss = lossMultiplier * loss;
            patience = patience - totalLoss;
            if (patience < 0)
            {
                // El jugador pierde
            } else
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
