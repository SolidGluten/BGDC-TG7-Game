using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(menuName = "Food/NewIngredient")]
public class IngredientsScriptable : ScriptableObject
{
    public string ingredientName;
    public Sprite ingredientSprite;
    public BaseIngredient baseIngredient;
}
