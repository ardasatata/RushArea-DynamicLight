using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoadData : MonoBehaviour {

    void Awake(){
        int[] Data = LoadData();
        Debug.LogWarning("load data");
        StaticStatesAndVariables.LifeData = Data[0];
        StaticStatesAndVariables.HealthData = Data[1];
        StaticStatesAndVariables.CoinData = Data[2];
        StaticStatesAndVariables.SfxState = (SFXState) Data[3];
        StaticStatesAndVariables.BgmState = (BGMState) Data[4];
        StaticStatesAndVariables.LifeCostData = Data[5];
        StaticStatesAndVariables.HealthCostData = Data[6];
        StaticStatesAndVariables.LatestLevel = Data[7];

    }

    public void SaveData(int Life, int Health, int Coin, int sfx, int bgm, int LifeCost, int HealthCost, int LatestLevel) {
        PlayerPrefs.SetInt("Health", Health);
        PlayerPrefs.SetInt("Life", Life);
        PlayerPrefs.SetInt("Coin", Coin);
        PlayerPrefs.SetInt("sfx", sfx);
        PlayerPrefs.SetInt("bgm", bgm);
        PlayerPrefs.SetInt("HealthCost", HealthCost);
        PlayerPrefs.SetInt("LifeCost", LifeCost);
        PlayerPrefs.SetInt("LatestLevel", LatestLevel);
    }


    public int[] LoadData() {
        int[] Data;
        if (PlayerPrefs.HasKey("sfx"))
        {
             Data = new int[] {
                 PlayerPrefs.GetInt("Life"),
                 PlayerPrefs.GetInt("Health"),
                 PlayerPrefs.GetInt("Coin"),
                 PlayerPrefs.GetInt("sfx"),
                 PlayerPrefs.GetInt("bgm"),
                 PlayerPrefs.GetInt("LifeCost"),
                 PlayerPrefs.GetInt("HealthCost"),
                 PlayerPrefs.GetInt("LatestLevel")
             };
        }
        else {
            Data = new int[] {
                3,      // Life
                2,      // Health
                60,     // Coin
                1,      // SFX
                1,      // BGM
                100,    // Life Cost
                10,     // Health Cost
                1       // Latest level
            };
        }
        
        return Data;
    }

    public void Save()
    {
        SaveData(StaticStatesAndVariables.LifeData, 
            StaticStatesAndVariables.HealthData, 
            StaticStatesAndVariables.CoinData, 
            (int)StaticStatesAndVariables.SfxState, 
            (int)StaticStatesAndVariables.BgmState,
            StaticStatesAndVariables.LifeCostData,
            StaticStatesAndVariables.HealthCostData,
            StaticStatesAndVariables.LatestLevel
            );
    }

}
