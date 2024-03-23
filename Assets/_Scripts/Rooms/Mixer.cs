using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Types;
using UnityEngine;

public class Mixer : MonoBehaviour
{
    public static Mixer instance { get; private set; }
    public GameObject foodObj;

    private void Awake()
    {
        if(instance != null && instance != this)
            Destroy(instance);
        else 
            instance = this; 
    }

    public List<MixRecipe> mixRecipes = new List<MixRecipe>();

    public FoodScriptable FindRecipe(FoodScriptable raw1, FoodScriptable raw2)
    {
        FoodScriptable recipe = mixRecipes
            .FirstOrDefault(recipe => (recipe._raw1 == raw1 && recipe._raw2 == raw2) || (recipe._raw1 == raw2 && recipe._raw2 == raw1))?
            ._output;

        return recipe ? recipe : null;
    }

    public GameObject MixFood(FoodHolder food1, FoodHolder food2)
    {
        //Mix dishes
        if (food1.type == FoodType.Dish && food2.type == FoodType.Dish)
        {
            FoodScriptable output = FindRecipe(food1.FoodScript, food2.FoodScript);
            if (output == null)
            {
                Debug.Log("No recipe found!");
                return null;
            }

            OverwriteFoodDetails(food1, food2);
            food1.FoodScript = output;  

            Destroy(food2.gameObject);
            return food1.gameObject;
        }

        if (food1.type == food2.type) return null;

        //Add side dish
        if (food1.type == FoodType.SideDish || food2.type == FoodType.SideDish)
        {
            FoodHolder sideDishHolder = food1.type == FoodType.SideDish ? food1 : food2;
            FoodHolder foodHolder = food1.type != FoodType.SideDish ? food1 : food2;

            OverwriteFoodDetails(foodHolder, sideDishHolder);
            Destroy(sideDishHolder.gameObject);
            return foodHolder.gameObject;
        }

        //Add drink
        if (food1.type == FoodType.Beverage || food2.type == FoodType.Beverage)
        {
            FoodHolder drinkHolder = food1.type == FoodType.Beverage ? food1 : food2;
            FoodHolder foodHolder = food1.type != FoodType.Beverage ? food1 : food2;

            OverwriteFoodDetails(foodHolder, drinkHolder);
            Destroy(drinkHolder.gameObject);
            return foodHolder.gameObject;
        }

        return null;
    }

    public void OverwriteFoodDetails(FoodHolder destination, FoodHolder from)
    {
        if (from.SideDish != SideDish.None) destination.SideDish = from.SideDish;
        if (from.DrinkType != DrinkType.None) destination.DrinkType = from.DrinkType;
        if (from.IsFermented != false) destination.IsFermented = from.IsFermented;
    }
}

[Serializable]
public class MixRecipe
{
    public FoodScriptable _raw1;
    public FoodScriptable _raw2;
    public FoodScriptable _output;
}
