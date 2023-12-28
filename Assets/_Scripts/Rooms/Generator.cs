using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using System.Threading.Tasks;

public class Generator : MonoBehaviour
{
    public List<IngredientsScriptable> spawnableIngredients;
    public GameObject ingredientPrefab;
    public BaseIngredient ingredientToSpawn;
    public IngredientHolder ingredientHolder;

    public virtual void GenerateIngredient()
    {
        foreach (IngredientsScriptable ingredients in spawnableIngredients)
        {
            if(ingredientToSpawn == ingredients.baseIngredient)
            {
                GameObject ingredientObj = Instantiate(ingredientPrefab, ingredientHolder.transform.position, Quaternion.identity);
                ingredientObj.GetComponent<Ingredient>().ingredientsScriptable = ingredients;
                ingredientObj.transform.parent = transform;

                if(ingredientHolder.ingredient == ingredientObj)
                {
                    return;
                }

                if(ingredientHolder.ingredient != null)
                {
                    Destroy(ingredientHolder.ingredient);
                }

                ingredientHolder.ingredient = ingredientObj;
                return;
            }
        }

        Debug.Log("Ingredients Not Found!");
    }
}
