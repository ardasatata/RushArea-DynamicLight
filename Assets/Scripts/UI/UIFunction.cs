using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour {

	public GameState gameState;

	public GameObject UpGradePanel, MainMenuPanel;

    public SaveLoadData saveLoad;


    public void StartGame(){
        StaticStatesAndVariables.CurrentLevel = 0;
        SceneManager.LoadScene((int)SceneNumber.GamePlay);
		Time.timeScale = 1;
        
	}

	public void Pause(){
		Time.timeScale = 0;
		gameState.gameState = GameStates.Paused;
	}

	public void GameOver(){
		
	}

	public void Resume(){
		gameState.gameState = GameStates.Running;
	}

	public void Restart(){
        StaticStatesAndVariables.CurrentLevel = 0;
		Application.LoadLevel(Application.loadedLevel);
	}

    public void BackToMainMenu() {
        if (SceneManager.GetActiveScene().buildIndex != ((int)SceneNumber.MainMenu)) { 
            SceneManager.LoadScene((int)SceneNumber.MainMenu);
        } else {
			MainMenuPanel.SetActive (true);
			UpGradePanel.SetActive (false);
		}	
	}



	public void SFXStateChange(){
        if (StaticStatesAndVariables.SfxState == SFXState.disabled)
            StaticStatesAndVariables.SfxState = SFXState.enabled;
        else
            StaticStatesAndVariables.SfxState = SFXState.disabled;
        saveLoad.Save();
        print("SFX : " + (int)StaticStatesAndVariables.SfxState);
    }


	public void BGMStateChange(){
        if (StaticStatesAndVariables.BgmState == BGMState.disabled)
            StaticStatesAndVariables.BgmState = BGMState.enabled;
        else
            StaticStatesAndVariables.BgmState = BGMState.disabled;
        saveLoad.Save();
        print("BGM : " + (int)StaticStatesAndVariables.BgmState);
    }
    

	public void ShowUpgradePanel(){
		MainMenuPanel.SetActive (false);
		UpGradePanel.SetActive (true);
	}

	public void UpGradeLife(){
        if (StaticStatesAndVariables.CoinData >= StaticStatesAndVariables.LifeCostData)
        {
            StaticStatesAndVariables.LifeData += 1;
            StaticStatesAndVariables.CoinData -= StaticStatesAndVariables.LifeCostData;
            StaticStatesAndVariables.LifeCostData *= 2;
            saveLoad.Save();
        } else {
            Debug.Log("Not Engough COIN!!");
        }
        
	}

	public void UpGradeHealth(){
        if (StaticStatesAndVariables.CoinData >= StaticStatesAndVariables.HealthCostData)
        {
            StaticStatesAndVariables.HealthData += 1;
            StaticStatesAndVariables.CoinData -= StaticStatesAndVariables.HealthCostData;
            StaticStatesAndVariables.HealthCostData += (10 * StaticStatesAndVariables.HealthData);
            saveLoad.Save();
        } else {
            Debug.Log("Not Engough COIN!!");
        }
    }

    public void Quit() {
        Debug.Log("Quit");
        //PlayerPrefs.DeleteAll();
        Application.Quit();
    }
    

}
