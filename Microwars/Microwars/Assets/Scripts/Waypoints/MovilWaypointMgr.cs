using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovilWaypointMgr : MonoBehaviour {

    public PlayerDetection playerDetection;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Marta"))
        {
            other.GetComponent<MartaCharacterMgr>().PlayAviso();
            StartCoroutine("Movil", other.gameObject);
        }
    }

    IEnumerator Movil(GameObject player)
    {
       
        yield return new WaitForSeconds(1);
        player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animators/Marta-movil");
        player.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(1);
        playerDetection.detected = false;
        yield return new WaitForSeconds(9);
        if (!MartaCharacterMgr.DEAD) {
            player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
            playerDetection.detected = true;
        }
    }
}
