using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public enum PotType {Water, Oil}

public class FrySoup : Processor
{
    public PotType currentType = PotType.Water;
    public Room room;
    public GameObject foodHolder;
    public List<Recipe> fryRecipeList = new List<Recipe>();
    public List<Recipe> soupRecipeList = new List<Recipe>();
    public float currTemperature;
    public float rightTemperature;
    public float maxTemperature;
    [SerializeField] private bool isHotEnough;
    [SerializeField] private bool isHeatOn;

    private FoodScriptable processedFood;

    private void Start()
    {
        room = GetComponentInParent<Room>();
    }

    private void Update()
    {
        isHotEnough = currTemperature >= rightTemperature ? true : false;
        if(currTemperature >= maxTemperature)
        {
            GameManager.instance.Death(DeathCondition.HotPot);
            TurnOffHeat();
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

    public void ChangeWater()
    {
        if (currentType == PotType.Oil) currentType = PotType.Water;
        ResetHeat();
    }

    public void ChangeOil() {
        if (currentType == PotType.Water) currentType = PotType.Oil;
        ResetHeat();
    }

    public GameObject ProcessPotFood(FoodHolder foodInPot)
    {
        if (!isHotEnough)
        {
            Debug.Log("Not hot enough!");
            return null;
        }

        if (currentType == PotType.Water) 
            processedFood = FindSoupDish(foodInPot.FoodScript);   
        else
            processedFood = FindFryDish(foodInPot.FoodScript);

        if(processedFood == null) {
            Debug.Log("No recipe found!");
            return null;
        }

        return ProcessFood(foodInPot, processedFood);
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
