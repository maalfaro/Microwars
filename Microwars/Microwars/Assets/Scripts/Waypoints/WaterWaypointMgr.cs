using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterWaypointMgr : WaypointMgr
{
    [SerializeField]
    private GameObject waterSprite;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JuanD"))
        {
            StartCoroutine("GetWater", other.gameObject);
        }

        if (other.gameObject.CompareTag("Marta"))
        {
            StartCoroutine("GetWaterMarta", other.gameObject);
        }
    }

    IEnumerator GetWater(GameObject player)
    {
        player.gameObject.SendMessage("ShowNoodles", false, SendMessageOptions.DontRequireReceiver);
        yield return new WaitForSeconds(1);
        player.GetComponent<JuanDCharacterMgr>().SetImage("Images/SpriteJ-Agua");
        waterSprite.SetActive(true);
        yield return new WaitForSeconds(2);
        waterSprite.SetActive(false);
        player.gameObject.SendMessage("ShowNoodles", true, SendMessageOptions.DontRequireReceiver);
        player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver); 
        player.GetComponent<JuanDCharacterMgr>().SetImage("Images/JuanD_walk_micro");
        player.GetComponent<JuanDCharacterMgr>().PlayFideosAlMicro();
    }

    IEnumerator GetWaterMarta(GameObject player)
    {
        yield return new WaitForSeconds(1);
        waterSprite.SetActive(true);
        yield return new WaitForSeconds(2);
        waterSprite.SetActive(false);
        player.gameObject.SendMessage("goToNextState", SendMessageOptions.DontRequireReceiver);
        player.GetComponent<MartaCharacterMgr>().PlayFideosAlMicro();
    }

}
