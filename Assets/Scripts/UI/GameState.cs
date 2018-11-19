using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour {

	public GameStates gameState = GameStates.Running;

    public SFXState sfxState;

    public BGMState bgmState;

	UIRunningMenu UIRunning;
	UIPauseMenu UIPause;
	UIGameOverMenu UIGameOver;


    void Awake(){
        gameState = GameStates.Running;
        UIPause = GetComponent<UIPauseMenu> ();
		UIRunning = GetComponent<UIRunningMenu> ();
		UIGameOver = GetComponent<UIGameOverMenu> ();
	}

    void Update(){
        sfxState = StaticStatesAndVariables.SfxState;
        bgmState = StaticStatesAndVariables.BgmState;

        switch (gameState) {
		case GameStates.Running:
			UIRunning.Show ();
			UIPause.Hide ();
			UIGameOver.Hide ();
			break;
		case GameStates.Paused:
			UIRunning.Hide ();
			UIPause.Show ();
			UIGameOver.Hide ();
			break;
		case GameStates.GameOver:
			UIRunning.Hide ();
			UIPause.Hide ();
			UIGameOver.Show ();
			break;
		
		}
		
	}

}
