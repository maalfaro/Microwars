using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EyeLogic : MonoBehaviour {
    public bool opened = false;
    public Sprite openedSprite;
    public Sprite closedSprite;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        setSprite();
    }

    void setSprite () {
        if (opened)
        {
            image.sprite = openedSprite;
        }
        else
        {
            image.sprite = closedSprite;
        }	
	}
}
