using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodlesWaypointMgr : WaypointMgr
{


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JuanD"))
        {
            StartCoroutine("GetNoodles",other.gameObject);
        }
    }

    IEnumerator GetNoodles(GameObject player)
    {
        yield return new WaitForSeconds(1);
        GameObject.FindGameObjectWithTag("Noodles").SetActive(false);
        yield return new WaitForSeconds(1);
        player.gameObject.SendMessage("ShowNoodles", true, SendMessageOptions.DontRequireReceiver);
        player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
    }
}
