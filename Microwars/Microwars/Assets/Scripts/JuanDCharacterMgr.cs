using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuanDCharacterMgr : MonoBehaviour {

    private string[] PATH = new string[] { "EntraCocina", "Noodles", "Agua", "RoundTable1", "RoundTable2", "Microwave", "RoundTable2", "RoundTable1", "Karate", "RoundTable1", "RoundTable2", "Microwave", "RoundTable3" };
    [SerializeField]
    private AudioClip[] sounds = new AudioClip[] { };

    [SerializeField]
    private int state = -1;
    [SerializeField]
    private GameObject waypoints;
    private Vector3 targetPosition;
    private bool isMoving = false;

    [SerializeField]
    private PlayerDetection playerDetection;

    // Use this for initialization
    void Start () {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints");
        goToNextState();
        StartCoroutine("PlayFirstAudio");
    }
	
	// Update is called once per frame
	void Update () {
		if(isMoving)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);

    }

    public void goToNextState()
    {

        state++;
        if(state< PATH.Length) { 
            print(PATH[state]);
            isMoving = true;
            targetPosition =waypoints.transform.FindChild(PATH[state]).transform.position;
            ChangeImage();
        }
    }

    public void ChangeImage()
    {
        if(transform.position.z> waypoints.transform.FindChild(PATH[state]).transform.position.z)
        {
            //TODO Front image
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/JuanD_front");
            playerDetection.detected = true;
        }
        else
        {
            //TODO Back image
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/JuanD_back");
            playerDetection.detected = false;
        }

    }

    public void SetImage(string path)
    {
        GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>(path);
    }

    public void ShowNoodles(bool show)
    {
        transform.FindChild("Noodles").gameObject.SetActive(show);
    }


    public void HideAnimator()
    {
        GetComponent<Animator>().enabled = false;
    }

    public void HideNoodles()
    {
        GameObject.FindGameObjectWithTag("Noodles").SetActive(false);
    }

    IEnumerator PlayFirstAudio()
    {
        yield return new WaitForSeconds(4);
        GetComponent<AudioSource>().PlayOneShot(sounds[0]);
    }


    public void PlayFideosAlMicro()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
    }

    public void PlayKatas()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[2]);
    }

    public void StopPlayKatas()
    {
        GetComponent<AudioSource>().Stop();
    }

    public void PlayFideosListos()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[3]);
    }
    public void PlayLTF()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[4]);
    }
}
