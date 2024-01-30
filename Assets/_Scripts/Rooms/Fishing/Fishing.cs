using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using System.Threading.Tasks;
using System.Threading;
using TMPro;
using System;
using System.Linq;

public class Fishing : Generator
{
    public List<FishItem> fishItems = new List<FishItem>();

    public void Awake()
    {
        int index = 0;
        foreach (var ingredient in ingredientsList)
        {
            fishItems[index]._ingredient = ingredient;
            index++;
        }
        RandomizeAllID();
    }

    public FoodScriptable FindFish(string id)
    {
        return fishItems.FirstOrDefault(item => string.Compare(item._ID, id) == 0)?._ingredient;
    }

    public void GenerateFish(string id)
    {
        FoodScriptable ingredientToSpawn = FindFish(id);
        if (ingredientToSpawn == null)
        {
            Debug.Log("Fish Not FOUND!");
            return;
        }

        GenerateIngredient(ingredientToSpawn);
        RandomizeAllID();
    }

    public void RandomizeAllID()
    {
        foreach (FishItem item in fishItems)
        {
            string randomId;
            do
            {
                randomId = GetRandomID();
            } while (fishItems.FirstOrDefault(item => string.Compare(item._ID, randomId) == 0) != null);
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
public class FishItem
{
    public FoodScriptable _ingredient;
    public string _ID;
}
