using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public enum PotType {Water, Oil}

public class FrySoup : Processor
{
    public PotType currentType = PotType.Water;
    public Room frySoupRoom;
    public GameObject foodHolder;
    public List<Recipe> fryRecipeList = new List<Recipe>();
    public List<Recipe> soupRecipeList = new List<Recipe>();
    public float currTemperature;
    public float maxTemperature;
    [SerializeField] private bool isHot;
    [SerializeField] private bool isHeating;

    public void TurnOnHeat()
    {
        if (isHeating) return;
        StartCoroutine("I_TurnOnHeat");
    }

    public IEnumerator I_TurnOnHeat()
    {
        isHeating = true;
        while(currTemperature < maxTemperature)
        {
            currTemperature += Time.deltaTime;
            yield return null;
        }
        isHeating = false;
        isHot = true;
    }

    public void ChangePot()
    {
        if(currentType == PotType.Water)
            currentType = PotType.Oil;
        else
            currentType = PotType.Water;

        ResetHeat();
    }

    public GameObject ProcessPotFood(FoodScriptable input)
    {
        if (!isHot)
        {
            Debug.Log("Not hot enough!");
            return null;
        }

        FoodScriptable foodToSpawn;
        if(currentType == PotType.Water)
            foodToSpawn = FindSoupDish(input);   
        else
            foodToSpawn = FindFryDish(input);

        if(foodToSpawn == null) {
            Debug.Log("No recipe found!");
            return null;
        }

        ResetHeat();
        return ProcessFood(foodHolder.transform.position, foodToSpawn);
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

    public void ResetHeat()
    {
        StopCoroutine("I_TurnOnHeat");
        isHot = false;
        currTemperature = 0;
        isHeating = false;
    }
}
