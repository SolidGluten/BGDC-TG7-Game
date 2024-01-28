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

    public void MakeMix(FoodScriptable mixFood, Vector2 pos, Transform parent)
    {
        GameObject mixObj = Instantiate(foodObj, pos, Quaternion.identity, parent);
        mixObj.GetComponent<FoodHolder>().food = mixFood;
    }

    public void AddSideDish(FoodHolder holder, SideDish type)
    {
        holder.sideDish = type;
    }

    public void AddDrink(FoodHolder holder, DrinkType type)
    {
        holder.drinkType = type;
    }
}

[Serializable]
public class MixRecipe
{
    public FoodScriptable _raw1;
    public FoodScriptable _raw2;
    public FoodScriptable _output;
}
