using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SendButton : MonoBehaviour
{
    public UnityEvent onButtonPressed;

    private void OnMouseDown()
    {
        onButtonPressed.Invoke();
    }
}