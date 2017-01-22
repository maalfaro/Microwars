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

    [SerializeField]
    private LEDTimerMgr ledTimeMgr;

    private bool isFirst = true;
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JuanD"))
        {
            StartCoroutine("Wait", other.gameObject);
        }

        if (other.gameObject.CompareTag("Marta"))
        {
            StartCoroutine("WaitMarta", other.gameObject);
        }
    }

    IEnumerator Wait(GameObject player)
    {
        if (openButtonMgr.isVisible)
            openButtonMgr.ShowBackground();
        player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animators/RecogiendoRamen");
        player.GetComponent<Animator>().enabled = true;
        
        yield return new WaitForSeconds(2);
        if (!JuanDCharacterMgr.DEAD) {
            if (!isFirst)
            {
                player.GetComponent<JuanDCharacterMgr>().PlayLTF();
            }else
            {
                ledTimeMgr.SetTime(10);
            }
            player.GetComponent<Animator>().enabled = false;
            if(!openButtonMgr.isVisible)
                openButtonMgr.CloseDoor();
            player.gameObject.SendMessage("ShowNoodles", !isFirst, SendMessageOptions.DontRequireReceiver);
            player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
            noodlesMicrowave.gameObject.SetActive(isFirst);
            isFirst = !isFirst;
        }
    }

    IEnumerator WaitMarta(GameObject player)
    {
        if (openButtonMgr.isVisible)
            openButtonMgr.ShowBackground();
        player.GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animators/Marta-metiendoTe");
        player.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        if (!MartaCharacterMgr.DEAD)
        {
            if (!isFirst)
            {
                player.GetComponent<MartaCharacterMgr>().PlayPuerta();
            }
            else
            {
                ledTimeMgr.SetTime(10);
            }
            player.GetComponent<Animator>().enabled = false;
            if (!openButtonMgr.isVisible)
                openButtonMgr.ShowBackground();
            player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
            noodlesMicrowave.gameObject.SetActive(isFirst);
            isFirst = !isFirst;
        }
    }
}
