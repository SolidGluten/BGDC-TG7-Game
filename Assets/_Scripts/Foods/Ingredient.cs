using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientsScriptable ingredientsScriptable;
    private SpriteRenderer spriteRender;
    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        spriteRender.sprite = ingredientsScriptable.ingredientSprite;
    }
}
