using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIGameOverMenu : MonoBehaviour {

    public UIFunction uiF;

    public GameObject[] ObjToShow;

	void Start () {

	}

	public void Show () {
		foreach (GameObject obj in ObjToShow) {
			obj.SetActive (true);
		}
        StaticStatesAndVariables.LatestLevel = 
            StaticStatesAndVariables.CurrentLevel > StaticStatesAndVariables.LatestLevel ? 
            StaticStatesAndVariables.CurrentLevel : StaticStatesAndVariables.LatestLevel;

        uiF.saveLoad.Save();
    }

	public void Hide () {
		foreach (GameObject obj in ObjToShow) {
			obj.SetActive (false);
		}
	}
}
