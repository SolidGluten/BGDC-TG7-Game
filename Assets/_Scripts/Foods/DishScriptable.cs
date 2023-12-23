using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Food/NewDish")]
public class DishScriptable : ScriptableObject
{
    public string dishName;
    public Sprite dishSprite;
    public List<IngredientsScriptable> ingredients = new List<IngredientsScriptable>();
    public List<DishScriptable> dishes = new List<DishScriptable>();
}
