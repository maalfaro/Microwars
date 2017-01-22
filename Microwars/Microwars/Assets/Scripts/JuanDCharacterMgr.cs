using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JuanDCharacterMgr : MonoBehaviour {

    private string[] PATH = new string[] { "EntraCocina", "Noodles", "Agua", "RoundTable1", "RoundTable2", "Microwave", "RoundTable2", "RoundTable1", "Karate", "RoundTable1", "RoundTable2", "Microwave", "RoundTable3" };

    [SerializeField]
    private int state = -1;
    [SerializeField]
    private GameObject waypoints;
    private Vector3 targetPosition;
    private bool isMoving = false;

	// Use this for initialization
	void Start () {
        waypoints = GameObject.FindGameObjectWithTag("Waypoints");
        goToNextState();
    }
	
	// Update is called once per frame
	void Update () {
		if(isMoving)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 10 * Time.deltaTime);

    }

    public void goToNextState()
    {
        state++;
        print(PATH[state]);
        isMoving = true;
        targetPosition =waypoints.transform.FindChild(PATH[state]).transform.position;
        ChangeImage();
    }

    private void ChangeImage()
    {
        if(transform.position.z> waypoints.transform.FindChild(PATH[state]).transform.position.z)
        {
            //TODO Front image
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/JuanD_front");
        }
        else
        {
            //TODO Back image
            GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/JuanD_back");
        }

    }

    public void ShowNoodles(bool show)
    {
        transform.FindChild("Noodles").gameObject.SetActive(show);
    }



}
