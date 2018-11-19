using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUpgradeMenu : MonoBehaviour {

    public Text health, life, Coin;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        health.text = StaticStatesAndVariables.HealthData+"";
        life.text = StaticStatesAndVariables.LifeData+"";
        Coin.text = "X  " + StaticStatesAndVariables.CoinData + "";
    }
}
