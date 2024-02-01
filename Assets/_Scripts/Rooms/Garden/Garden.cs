using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Types;
using UnityEngine;

public class Garden : Generator
{
    public List<PlantItem> PlantItems = new List<PlantItem>();

    public void Awake()
    {
        int index = 0;
        foreach (var ingredient in ingredientsList)
        {
            PlantItems[index]._ingredient = ingredient;
            index++;
        }
        RandomizeAllID();
    }

    public FoodScriptable FindPlant(string id)
    {
        return PlantItems.FirstOrDefault(item => string.Compare(item._ID, id) == 0)?._ingredient;
    }

    public void GeneratePlant(string id)
    {
        FoodScriptable ingredientToSpawn = FindPlant(id);
        if (ingredientToSpawn == null)
        {
            Debug.Log("Plant Not FOUND!");
            GameManager.instance.Death(DeathCondition.Garden);
            return;
        }

        GenerateIngredient(ingredientToSpawn);
        RandomizeAllID();
    }

    public void RandomizeAllID()
    {
        foreach (PlantItem item in PlantItems)
        {
            string randomId;
            do
            {
                randomId = GetRandomID();
            } while (PlantItems.FirstOrDefault(item => string.Compare(item._ID, randomId) == 0) != null);
            item._ID = randomId;
        }
    }

    public string GetRandomID()
    {
        //A-D
        char letter = (char)(65 + UnityEngine.Random.Range(0, 4));
        //1-4
        int num = UnityEngine.Random.Range(1, 5);

        return letter + num.ToString();
    }
}

[Serializable]
public class PlantItem
{
    public FoodScriptable _ingredient;
    public string _ID;
}
