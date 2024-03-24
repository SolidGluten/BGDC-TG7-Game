using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Continue : MenuItem 
{
    public override void OnSelect() {
        StartCoroutine(LevelManager.instance.ChangeLevel(LevelManager.instance.currentLevelIndex + 1));   
    }
}
