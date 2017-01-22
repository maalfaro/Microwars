using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrowaveWaypointMgr : WaypointMgr
{

    [SerializeField]
    private Image noodlesMicrowave;

    private bool isFirst = true;
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
        player.gameObject.SendMessage("ShowNoodles", !isFirst, SendMessageOptions.DontRequireReceiver);
        player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
        noodlesMicrowave.gameObject.SetActive(isFirst);
        isFirst = !isFirst;
    }
}
