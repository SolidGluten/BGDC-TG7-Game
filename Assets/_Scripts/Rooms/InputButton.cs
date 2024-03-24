using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider2D))]
public class InputButton : MonoBehaviour
{
    [SerializeField] private UnityEvent onButtonClick;
    private SpriteRenderer buttonSprite;
    private float amount = 0.2f;
    private Color baseColor;

    private void Start()
    {
        buttonSprite = GetComponent<SpriteRenderer>();
        baseColor = buttonSprite.color;
    }

    public virtual void OnMouseDown()
    {
        onButtonClick?.Invoke();
        buttonSprite.color = new Color(baseColor.r - amount, baseColor.g - amount, baseColor.b - amount);
    }

    private void OnMouseUp()
    {
        buttonSprite.color = new Color(baseColor.r + amount, baseColor.g + amount, baseColor.b + amount);
    }
}
