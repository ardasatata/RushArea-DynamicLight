using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgmHandler : MonoBehaviour {

    public AudioClip[] bgm;

    public AudioSource source;

    public static bool playBGM;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (playBGM && StaticStatesAndVariables.BgmState == BGMState.enabled)
        {
            source.clip = bgm[StaticStatesAndVariables.CurrentLevel - 1];
            if (!source.isPlaying)
                source.Play();
        }
        else if(StaticStatesAndVariables.BgmState == BGMState.disabled){
            if (source.isPlaying)
                source.Stop();
        }
	}
}
