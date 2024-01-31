using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_BackButton : MenuItem
{
    public UnityEvent OnClickEvent;

    public override void OnSelect()
    {
        OnClickEvent?.Invoke();
    }
}
