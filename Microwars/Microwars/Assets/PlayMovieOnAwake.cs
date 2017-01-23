using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayMovieOnAwake : MonoBehaviour {

    private GameObject video;
    private AudioClip audioClip;
    private AudioSource audioSource;
    public Image lostImage;

    void Start()
    {
        video = GameObject.FindGameObjectWithTag("IntroVideo");

        Renderer renderer = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)renderer.material.mainTexture;
        if (movie != null) { 
            audioClip = movie.audioClip;
            audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.clip = audioClip;
            audioSource.Play();
            movie.Play();
            StartCoroutine("destroyOnEnd", movie.duration);
        }else
        {
            MenuSceneManager.instance.ActivateCanvas();
            lostImage.gameObject.SetActive(true);
        }
    }

    IEnumerator destroyOnEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        video.SetActive(false);
        MenuSceneManager.instance.ActivateCanvas();
    }
}
