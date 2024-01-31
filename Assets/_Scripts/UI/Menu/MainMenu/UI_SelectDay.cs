using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_SelectDay : MenuItem
{
    public UnityEvent OnSelectEvent;

    public override void OnSelect()
    {
        OnSelectEvent?.Invoke();
    }
}
