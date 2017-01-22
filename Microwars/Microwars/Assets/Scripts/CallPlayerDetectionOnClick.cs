using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CallPlayerDetectionOnClick : MonoBehaviour {

    public int loss = 1;
    private GameObject playerDetection;
    public int count = 0;

    private Button btn;

    void Start()
    {
        btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(SendMessageOnClick);
        playerDetection = GameObject.FindGameObjectWithTag("PlayerDetection");
    }

    void SendMessageOnClick()
    {
        playerDetection.SendMessage("msg_microwaveActing", loss);
        count++;
        //print("entro " + count);
    }
}
