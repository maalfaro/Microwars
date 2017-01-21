using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class MoveCameraMgr : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    public float offset = 1f;
    public GameObject maxPositionL;
    public GameObject maxPositionR;
    bool _pressed = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
        if (!_pressed)
            return;
        moveCamera();

    }

    public abstract void moveCamera();
}
