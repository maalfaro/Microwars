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
        yield return new WaitForSeconds(2);
        player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);

    }
}
