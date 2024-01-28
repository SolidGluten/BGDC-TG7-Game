using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorIndicator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Drink drink;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        spriteRenderer.color = drink.currentColor;
    }
}
