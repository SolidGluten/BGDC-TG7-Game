using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class Generator : MonoBehaviour
{
    public List<IngredientsScriptable> spawnableIngredients;
    public GameObject ingredientPrefab;

    public void GenerateIngredient(Vector2 SpawnPos, IngredientsScriptable ingredient)
    {
        foreach (IngredientsScriptable ingredients in spawnableIngredients)
        {
            if(ingredient.baseIngredient == ingredients.baseIngredient)
            {
                GameObject ingredientObj = Instantiate(ingredientPrefab, SpawnPos, Quaternion.identity);
                ingredientObj.GetComponent<Ingredient>().ingredientsScriptable = ingredients;
                return;
            }
        }

        Debug.Log("Ingredients Not Found!");
    }
}
