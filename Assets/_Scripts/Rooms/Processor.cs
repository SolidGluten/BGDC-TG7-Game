using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Processor : MonoBehaviour
{
    public List<Recipe> recipeList = new List<Recipe>();
    public GameObject FoodObj;

    public FoodScriptable FindOutputDish(FoodScriptable raw)
    {
        FoodScriptable output = recipeList.FirstOrDefault(recipe => recipe._rawInput == raw)?._processedOutput;

        return output ? output : null;
    }

    //Spawn Processed Food
    public GameObject ProcessFood(Vector2 spawnPos, FoodScriptable processedFood)
    {
        GameObject foodObj = Instantiate(FoodObj, spawnPos, Quaternion.identity, this.transform);
        foodObj.GetComponent<FoodHolder>().food = processedFood;
        return foodObj;
    }
}

[Serializable]
public class Recipe
{
    public FoodScriptable _rawInput;
    public FoodScriptable _processedOutput;
}

