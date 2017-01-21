using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeButtonMgr : ButtonPressed {

    public Sprite[] timeButtonSprites = new Sprite[36];
    private int counter = 34;
    private float timer = 0.0f;

    public LEDTimerMgr ledTimeMgr;

    void Update()
    {
        ledTimeMgr._pressed = _pressed;
        if (_pressed) {
            return;
        }
        timer += Time.deltaTime;
        if (timer > 2.5f)
        {
            OnButtonPressed();
            timer =0.0f;
        }

    }

    public override void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
        ledTimeMgr._pressed = false;
        ledTimeMgr.StartCoroutine("Counter");
    }

    public override void OnButtonPressed()
    {
        GetComponent<Image>().sprite = timeButtonSprites[counter--];
        //TODO Hacer que pite
    }
}
