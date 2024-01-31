using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Resume : MenuItem
{
    public override void OnSelect()
    {
        GameManager.instance.Resume();
    }
}
