using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class ButtonPressed : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{


    public float offset = 1f;
    public GameObject maxPositionL;
    public GameObject maxPositionR;
    protected bool _pressed = false;


    public void OnPointerDown(PointerEventData eventData)
    {
        _pressed = true;

    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        _pressed = false;
    }

    void Update()
    {
        if (!_pressed)
            return;
        OnButtonPressed();

    }

    public abstract void OnButtonPressed();
}
