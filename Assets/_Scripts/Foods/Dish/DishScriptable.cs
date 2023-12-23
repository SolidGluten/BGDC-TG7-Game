using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

[CreateAssetMenu(menuName = "Food/NewDish")]
public class DishScriptable : ScriptableObject
{
    public string dishName;
    public Sprite dishSprite;
    public DishType dishType;
    public List<IngredientsScriptable> ingredients = new List<IngredientsScriptable>();
}
