using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LifeCost : MonoBehaviour {

    public Text text;

	// Use this for initialization
	void Start () {
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(StaticStatesAndVariables.LifeCostData!=null)
        text.text = "" + StaticStatesAndVariables.LifeCostData;
	}
}
