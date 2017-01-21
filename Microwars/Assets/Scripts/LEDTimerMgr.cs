using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDTimerMgr : MonoBehaviour{

    [SerializeField]
    public string[] wordsList = new string[] { "Kill", "Pepe", "With", "Duck" };

    private Text ledText;
    private int textCount=0;
    public int timeLeft = 1;
    private bool showTime=true;

    void Start()
    {
        ledText = transform.FindChild("Text").GetComponent<Text>();
        StartCoroutine("Counter");
    }

    public void ShowNewText()
    {
        if (textCount > 3)
        {
            ledText.text = ParseTime(timeLeft);
            showTime = true;
            textCount = 0;
        }else
        {
            ledText.text = wordsList[textCount++];
            showTime = false;
        }
    }


    IEnumerator Counter()
    {
        timeLeft--;
        if (showTime)
            ledText.text = ParseTime(timeLeft);
        yield return new WaitForSeconds(1);
        if (timeLeft != 0)
            StartCoroutine("Counter");
    }


    public void AddTime()
    {
        timeLeft += 10;
        if (timeLeft > 60)
        {
            timeLeft = 60;
        }
        if (timeLeft == 10)
        {
            ledText.text = ParseTime(timeLeft);
            StartCoroutine("Counter");
        }
        ledText.text = ParseTime(timeLeft);
    }


    string ParseTime(int time)
    {
        if (time < 10)
        {
            return "00:0" + time;
        }else if (time == 60)
        {
            return "01:00";
        }
        else
        {
            return "00:" + time;
        }
    }
}

