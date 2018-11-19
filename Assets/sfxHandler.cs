using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxHandler : MonoBehaviour {

    Player player;

    public AudioClip[] sfx;

    public AudioSource source;

    public static int playSFX;

    // Use this for initialization
    void Start () {
        player = GetComponent<Player>();
	}
	
	// Update is called once per frame
	void Update () {
        if (StaticStatesAndVariables.SfxState == SFXState.enabled)
        {
            source.clip = sfx[playSFX];
            if (!source.isPlaying)
                source.Play();
        }
        else if (StaticStatesAndVariables.SfxState == SFXState.disabled)
        {
            if (source.isPlaying)
                source.Stop();
        }
    }

}
