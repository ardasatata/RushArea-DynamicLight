using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class nextLevelDisplay : MonoBehaviour {

    public static bool lastStages;

    public Text curLvText;
    
    public void Show() {
        if (lastStages)
        {
            curLvText.text = "Congratulation!! You Completed the Game" ;
        }
        else
        {
            curLvText.text = "Level : " + StaticStatesAndVariables.CurrentLevel;
        }
    }
}
