using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

enum PotType {Water, Oil}
public class FrySoup : Processor
{
    private PotType currentType = PotType.Water;
    private GameObject foodHolder;
    public List<Recipe> fryRecipeList = new List<Recipe>();
    public List<Recipe> soupRecipeList = new List<Recipe>();

    void ChangePot()
    {
        if(currentType == PotType.Water)
            currentType = PotType.Oil;
        else
            currentType = PotType.Water;
    }

    public void ProcessPotFood()
    {
        FoodScriptable foodToSpawn;
        if(currentType == PotType.Water)
            foodToSpawn = FindSoupDish(foodHolder.GetComponent<FoodHolder>().food);   
        else
            foodToSpawn = FindFryDish(foodHolder.GetComponent<FoodHolder>().food);

        if(foodToSpawn == null) {
            Debug.Log("No recipe found!");
            return;
        }


    }

    public FoodScriptable FindFryDish(FoodScriptable raw)
    {
        FoodScriptable output = fryRecipeList.FirstOrDefault(recipe => recipe._rawInput == raw)?._processedOutput;
        return output ? output : null;
    }

    public FoodScriptable FindSoupDish(FoodScriptable raw)
    {
        FoodScriptable output = soupRecipeList.FirstOrDefault(recipe => recipe._rawInput == raw)?._processedOutput;
        return output ? output : null;
    }
}
