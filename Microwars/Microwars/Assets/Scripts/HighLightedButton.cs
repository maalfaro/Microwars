using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HighLightedButton : MonoBehaviour {

    [SerializeField]
    private AnimationCurve curveColor;

    private float timer = 0.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        GetComponent<Image>().color= new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g,GetComponent<Image>().color.b, curveColor.Evaluate(timer));



    }

    //IEnumerator HighLight()
    //{




    //}


}
