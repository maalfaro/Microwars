using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public float animationDuration = 1.1f;

    public void LoadByIndex(int sceneIndex)
    {
        GameObject mCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mCamera.GetComponent<Animator>().SetBool("startGame", true);
        StartCoroutine("waitForAnimationToEnd", sceneIndex);
    }

    IEnumerator waitForAnimationToEnd(int sceneIndex)
    {
        yield return new WaitForSeconds(animationDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
