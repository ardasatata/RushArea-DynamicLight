using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuSoundHandler : MonoBehaviour {

    public AudioSource source;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (StaticStatesAndVariables.BgmState == BGMState.disabled)
        {
            source.enabled = false;
        }
        else {
            source.enabled = true;
        }
	}


}
