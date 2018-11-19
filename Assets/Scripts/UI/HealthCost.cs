using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthCost : MonoBehaviour {

    public Text text;

    // Use this for initialization
    void Start()
    {
        text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "" + StaticStatesAndVariables.HealthCostData;
    }
}
