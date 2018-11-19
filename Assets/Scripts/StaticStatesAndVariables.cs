using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticStatesAndVariables {
	private static SFXState sfxState;
	private static BGMState bgmState;
    private static int healthData, lifeData, coinData, healthCostData, lifeCostData, currentLevel, latestLevel;

    public static bool FisrtTime { get; set; }

	public static BGMState BgmState{
		get{ 
			return bgmState;
		}
		set{
			bgmState = value;
		}
	}

	public static SFXState SfxState{
		get{ 
			return sfxState;
		}
		set{
			sfxState = value;
		}
	}

    public static int HealthData
    {
        get
        {
            return healthData;
        }
        set
        {
            healthData = value;
        }
    }

    public static int LifeData
    {
        get
        {
            return lifeData;
        }
        set
        {
            lifeData = value;
        }
    }

    public static int HealthCostData
    {
        get
        {
            return healthCostData;
        }
        set
        {
            healthCostData = value;
        }
    }

    public static int LifeCostData
    {
        get
        {
            return lifeCostData;
        }
        set
        {
            lifeCostData = value;
        }
    }

    public static int CoinData
    {
        get
        {
            return coinData;
        }
        set
        {
            coinData = value;
        }
    }

    public static int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;
        }
    }

    public static int LatestLevel
    {
        get
        {
            return latestLevel;
        }
        set
        {
            latestLevel = value;
        }
    }

}
