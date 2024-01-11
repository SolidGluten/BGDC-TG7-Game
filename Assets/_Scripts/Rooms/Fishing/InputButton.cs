using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class InputButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onButtonClick;

    private void OnMouseDown()
    {
        onButtonClick?.Invoke();
    }
}
