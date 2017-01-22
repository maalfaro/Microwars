using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitWavepointMgr : WaypointMgr {

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("JuanD"))
        {
            SceneManager.LoadScene("JuanDemanScene");
        }

        if (other.gameObject.CompareTag("Marta"))
        {
            StartCoroutine("WaitMarta");
        }
    }

    IEnumerator WaitMarta()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MartaScene");
    }
}
