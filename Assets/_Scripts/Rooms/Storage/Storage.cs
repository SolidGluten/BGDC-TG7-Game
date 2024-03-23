using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class Storage : Generator
{
    public Room room;

    private void Start()
    {
        room = GetComponent<Room>();
    }

    public GameObject GetMeat(BaseIngredient ingredient, Transform pos)
    {
        FoodScriptable ingredientToSpawn = FindIngredients(ingredient);
        
        if (ingredientToSpawn == null)
        {
            Debug.Log("No ingredients found!");
            return null;
        }

        return SpawnIngredient(ingredientToSpawn, pos);
    }

}
