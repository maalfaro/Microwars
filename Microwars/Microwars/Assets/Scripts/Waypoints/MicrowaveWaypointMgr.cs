using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MicrowaveWaypointMgr : WaypointMgr
{

    [SerializeField]
    private Image noodlesMicrowave;

    [SerializeField]
    private OpenButtonMgr openButtonMgr;

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

        openButtonMgr.ShowBackground();
        player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animators/RecogiendoRamen");
        player.GetComponent<Animator>().enabled = true;
        if (!isFirst)
        {
            player.GetComponent<JuanDCharacterMgr>().PlayLTF();
        }

        yield return new WaitForSeconds(2);

        if (!JuanDCharacterMgr.DEAD) {
            player.GetComponent<Animator>().enabled = false;
            openButtonMgr.ShowBackground();
            player.gameObject.SendMessage("ShowNoodles", !isFirst, SendMessageOptions.DontRequireReceiver);
            player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
            noodlesMicrowave.gameObject.SetActive(isFirst);
            isFirst = !isFirst;
        }else
        {

        }
    }
}
