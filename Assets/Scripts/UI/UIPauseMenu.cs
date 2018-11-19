using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPauseMenu : MonoBehaviour {

	public GameObject[] ObjToShow;

	void Start () {
		
	}

	public void Show () {
		foreach (GameObject obj in ObjToShow) {
			obj.SetActive (true);
		}
	}

	public void Hide () {
		foreach (GameObject obj in ObjToShow) {
			obj.SetActive (false);
		}
	}
}
