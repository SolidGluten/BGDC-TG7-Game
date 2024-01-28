using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using System.Threading.Tasks;
using System.Linq;

public class Generator : MonoBehaviour
{
    public List<FoodScriptable> ingredientsList = new List<FoodScriptable>();
    public GameObject ingredientPrefab;
    public IngredientHolder ingredientHolder;

    public FoodScriptable FindIngredients(BaseIngredient baseIngredient)
    {
        return ingredientsList.FirstOrDefault(ingredient => ingredient._baseIngredient == baseIngredient);
    }

    public FoodScriptable FindBeverage(DrinkType drinkType)
    {
        return ingredientsList.FirstOrDefault(ingredient => ingredient._drink == drinkType);
    }

    public void GenerateIngredient(FoodScriptable ingredients)
    {
        GameObject ingredientObj = Instantiate(ingredientPrefab, ingredientHolder.transform.position, Quaternion.identity);
        FoodHolder foodHolder = ingredientObj.GetComponent<FoodHolder>();
           foodHolder.food = ingredients;
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
