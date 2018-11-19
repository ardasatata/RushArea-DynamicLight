using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayHealth : MonoBehaviour {

	// temporary
	public Text HealthText;

    public GameObject currentHealth;

	public Player player;

    private float HealthBarSize;

	// Use this for initialization
	void Start () {
        HealthBarSize = currentHealth.GetComponent<Image>().rectTransform.sizeDelta.x;

    }
	
	// Update is called once per frame
	void Update () {
		HealthText.text = "" + player.PlayerHealth + " / " + StaticStatesAndVariables.HealthData;

        currentHealth.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(HealthBarSize * ((float)player.PlayerHealth / (float)StaticStatesAndVariables.HealthData), currentHealth.GetComponent<Image>().rectTransform.sizeDelta.y);

	}
}
