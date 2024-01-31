using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Restart : MenuItem
{
    public override void OnSelect()
    {
        StartCoroutine(GameManager.instance.RetryLevel());
    }
}
