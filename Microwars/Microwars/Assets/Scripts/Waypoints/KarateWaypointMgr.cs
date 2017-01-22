using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarateWaypointMgr : WaypointMgr
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JuanD"))
        {
            StartCoroutine("Wait", other.gameObject);
        }
    }

    IEnumerator Wait(GameObject player)
    {

        player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animators/Katas");
        player.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(5);
        player.GetComponent<Animator>().enabled = false;
        player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
        player.GetComponent<JuanDCharacterMgr>().StopPlayKatas();
        player.GetComponent<JuanDCharacterMgr>().PlayFideosListos();
    }
}
