using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Processor : MonoBehaviour
{
    public List<DishScriptable> ProcessList = new List<DishScriptable>();
    public GameObject DishObj;

    public DishScriptable FindOutputDish(IngredientsScriptable currIngredient)
    {
        foreach(DishScriptable dish in ProcessList)
        {
            if(dish.ingredients.Contains(currIngredient))
            {
                return dish;
            }
        }

        Debug.Log("No dish found!");
        return null;
    }

    //Spawn Processed Food
    public void ProcessFood(Vector2 spawnPos, DishScriptable dish)
    {
        GameObject dishObj = Instantiate(DishObj, spawnPos, Quaternion.identity);
        dishObj.GetComponent<Dish>().dishScriptable = dish;
        dishObj.transform.parent = transform;
    }
}

