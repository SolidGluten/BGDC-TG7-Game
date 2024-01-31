using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Exit : MenuItem
{
    public override void OnSelect()
    {
        Application.Quit();
    }
}
