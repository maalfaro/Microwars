using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovieOnAwake : MonoBehaviour {

    private GameObject video;
    private AudioClip audioClip;
    private AudioSource audioSource;

    void Start()
    {
        video = GameObject.FindGameObjectWithTag("IntroVideo");

        Renderer renderer = GetComponent<Renderer>();
        MovieTexture movie = (MovieTexture)renderer.material.mainTexture;
        audioClip = movie.audioClip;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = audioClip;
        audioSource.Play();
        movie.Play();
        StartCoroutine("destroyOnEnd", movie.duration);
    }

    IEnumerator destroyOnEnd(float duration)
    {
        yield return new WaitForSeconds(duration);
        video.SetActive(false);
        MenuSceneManager.instance.ActivateCanvas();
    }
}
