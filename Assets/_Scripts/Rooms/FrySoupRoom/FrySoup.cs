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
    public float rightTemperature;
    public float maxTemperature;
    [SerializeField] private bool isHotEnough;
    [SerializeField] private bool isHeatOn;

    private void Update()
    {
        isHotEnough = currTemperature >= rightTemperature ? true : false;
        if(currTemperature >= maxTemperature)
        {
            GameManager.instance.Death(DeathCondition.HotPot);
        }
    }

    public void HeatSwitch()
    {
        if (isHeatOn) TurnOffHeat();
        else TurnOnHeat();
    }

    public void TurnOnHeat()
    {
        StartCoroutine("I_TurnOnHeat");
        StopCoroutine("I_TurnOffHeat"); 
    }

    public void TurnOffHeat()
    {
        StartCoroutine("I_TurnOffHeat");
        StopCoroutine("I_TurnOnHeat");
    }

    public IEnumerator I_TurnOnHeat()
    {
        isHeatOn = true;
        while(currTemperature < maxTemperature)
        {
            currTemperature += Time.deltaTime;
            yield return null;
        }
    }

    public IEnumerator I_TurnOffHeat()
    {
        isHeatOn = false;
        while (currTemperature > 0)
        {
            currTemperature -= Time.deltaTime;
            yield return null;
        }
    }

    public void ResetHeat()
    {
        currTemperature = 0;
        StopAllCoroutines();
        isHeatOn = false;
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
        if (!isHotEnough)
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
}
