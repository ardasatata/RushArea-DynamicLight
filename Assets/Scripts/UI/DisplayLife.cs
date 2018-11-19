using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayLife : MonoBehaviour {

	// temporary
	public Text LifeText;

	public Player player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		LifeText.text = "X " + player.PlayerLife;
	}
}
