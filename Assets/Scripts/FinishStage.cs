using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishStage : MonoBehaviour {

    public GameObject nextLevelScreen;

   // public GameObject[] StagesPrefebs;

    public GameObject[] Stages;

    // Use this for initialization
    void Awake() {

        foreach (var s in Stages) {
            Instantiate(s, Vector3.zero, transform.rotation, transform);
        }

        int n = transform.childCount;
        Stages = new GameObject[n];
        for (int i = 0; i < n; i++) {
            Stages[i] = transform.GetChild(i).gameObject;
        }

        nextLevelScreen.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

	}

}
