using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StartDay : MenuItem
{
    public override void OnSelect() {
        StartCoroutine(GameManager.instance.ChangeLevel(0));
    }
}
