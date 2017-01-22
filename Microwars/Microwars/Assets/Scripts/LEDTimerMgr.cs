using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LEDTimerMgr : MonoBehaviour{

    [SerializeField]
    public string[][] wordsList = new string[][] { new string[] { "Kill", "Pepe", "With", "Duck" },
                                                    new string[] { "DAN ", "THE ", "MAN " },
                                                    new string[] { "HELP", " ME "},
                                                    new string[] { "TAKE", " ME ", "ONE ", "BEER" }};
    [SerializeField]
    private string[] selectedWordList;

    private Text ledText;
    private int textCount=0;
    public int timeLeft = 1;
    private bool showTime=true;
    public bool _pressed = false;

    void Start()
    {
        ledText = transform.FindChild("Text").GetComponent<Text>();
        //StartCoroutine("Counter");
        selectedWordList = wordsList[Random.Range(0, wordsList.Length)];
    }

    public void ShowNewText()
    {
        if (textCount > selectedWordList.Length - 1)
        {
            ledText.text = ParseTime(timeLeft);
            showTime = true;
            textCount = 0;
            selectedWordList = wordsList[Random.Range(0, wordsList.Length)];
        }
        else
        {
            ledText.text = selectedWordList[textCount++];
            showTime = false;
        }
    }

    public void SetTime(int timeLeft)
    {
        this.timeLeft = timeLeft;
        StartCoroutine("Counter");
    }


    IEnumerator Counter()
    {
        if (!_pressed)
        {
            timeLeft--;
            if (showTime)
                ledText.text = ParseTime(timeLeft);
            yield return new WaitForSeconds(1);
            if (timeLeft != 0)
                StartCoroutine("Counter");
        }
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

