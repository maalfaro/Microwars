using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour
{
    public float animationDuration = 0.3f;
    public bool focus;

    public void LoadByIndex(int sceneIndex)
    {
        GameObject mCamera = GameObject.FindGameObjectWithTag("MainCamera");
        mCamera.GetComponent<Animator>().enabled = true;
        if (focus)
        {
            StartCoroutine("waitForAnimationToEnd", sceneIndex);
        } else
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    IEnumerator waitForAnimationToEnd(int sceneIndex)
    {
        yield return new WaitForSeconds(animationDuration);
        SceneManager.LoadScene(sceneIndex);
    }
}
