using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MartaCharacterMgr : MonoBehaviour
{

    public static bool DEAD = false;
    private string[] PATH = new string[] { "EntraCocina", "Agua", "RoundTable1", "RoundTable2", "Microwave", "Movil", "Microwave", "Exit" };
    [SerializeField]
    private AudioClip[] sounds = new AudioClip[] { };

    [SerializeField]
    public int state = -1;
    [SerializeField]
    private GameObject waypoints;
    private Vector3 targetPosition;
    private bool isMoving = false;

    [SerializeField]
    private PlayerDetection playerDetection;

    [SerializeField]
    private TextManager textManager;

    // Use this for initialization
    void Start()
    {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints");
        goToNextState();
        StartCoroutine("PlayFirstAudio");
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);

    }

    public void goToNextState()
    {

        state++;
        if (state < PATH.Length)
        {
            isMoving = true;
            targetPosition = waypoints.transform.FindChild(PATH[state]).transform.position;
            ChangeImage();
        }
    }

    public void ChangeImage()
    {
        if (transform.position.z > waypoints.transform.FindChild(PATH[state]).transform.position.z)
        {
            //TODO Front image
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/Marta/Marta");
            playerDetection.detected = true;
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
        textManager.setTextGui(0);
        StartCoroutine("RemoveText", 4);
    }


    public void PlayFideosAlMicro()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[1]);
        textManager.setTextGui(1);
        StartCoroutine("RemoveText", 7);
    }

    public void PlayAviso()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[2]);
        textManager.setTextGui(2);
    }

    public void StopPlayKatas()
    {
        GetComponent<AudioSource>().Stop();
        textManager.RemoveText();
    }

    public void PlayPuerta()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[3]);
        textManager.setTextGui(3);
        StartCoroutine("RemoveText", 10);
    }
    public void PlayLTF()
    {
        GetComponent<AudioSource>().PlayOneShot(sounds[4]);
        textManager.setTextGui(4);
        StartCoroutine("RemoveText", 4);
    }

    public void PlayMuerte()
    {
        GetComponent<AudioSource>().Stop();
        GetComponent<AudioSource>().PlayOneShot(sounds[6]);
        textManager.setTextGui(5);
        StartCoroutine("RemoveText", 3.5f);
    }

    public void Blood()
    {

    }

    public void Muerte()
    {
        
        GetComponent<Animator>().runtimeAnimatorController = Resources.Load<RuntimeAnimatorController>("Animators/Marta-muerte");
        StartCoroutine("Win");
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("WinStageScene");
    }

    IEnumerator RemoveText(int time)
    {
        yield return new WaitForSeconds(time);
        textManager.RemoveText();
    }
}