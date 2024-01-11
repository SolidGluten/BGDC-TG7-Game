using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using System.Threading.Tasks;
using System.Linq;

public class Generator : MonoBehaviour
{
    public List<IngredientsScriptable> spawnableIngredients;
    public GameObject ingredientPrefab;
    public IngredientHolder ingredientHolder;

    public IngredientsScriptable FindIngredients(BaseIngredient baseIngredient)
    {
        return spawnableIngredients.FirstOrDefault(ingredient => ingredient.baseIngredient == baseIngredient);
    }

    public void GenerateIngredient(IngredientsScriptable ingredients)
    {
        GameObject ingredientObj = Instantiate(ingredientPrefab, ingredientHolder.transform.position, Quaternion.identity);
        ingredientObj.GetComponent<Ingredient>().ingredientsScriptable = ingredients;
        ingredientObj.transform.parent = transform;

        if (ingredientHolder.ingredient == ingredientObj)
        {
            return;
        }

        if (ingredientHolder.ingredient != null)
        {
            Destroy(ingredientHolder.ingredient);
        }

        ingredientHolder.ingredient = ingredientObj;
        return;
    }
}
