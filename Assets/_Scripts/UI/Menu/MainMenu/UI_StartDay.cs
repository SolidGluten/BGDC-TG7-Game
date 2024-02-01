using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartDay : MenuItem
{
    public override void OnSelect() {
        StartCoroutine(LevelManager.instance.ChangeLevel(0));
    }
}
