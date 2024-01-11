using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class Storage : Generator
{
    public void GetMeat(BaseIngredient ingredient)
    {
        IngredientsScriptable ingredientToSpawn = FindIngredients(ingredient);
        if (ingredientToSpawn == null)
        {
            Debug.Log("No ingredients found!");
            return;
        }

        GenerateIngredient(ingredientToSpawn);
    }
}
