using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public IngredientsScriptable ingredientsScriptable;
    private SpriteRenderer spriteRender;
    private void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        gameObject.name = ingredientsScriptable.name;
        spriteRender.sprite = ingredientsScriptable.ingredientSprite;
    }
}
