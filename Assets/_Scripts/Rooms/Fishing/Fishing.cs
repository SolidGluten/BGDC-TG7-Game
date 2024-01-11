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

    public void Start()
    {
        foreach (var ingredient in spawnableIngredients)
        {
            string randomId;
            do
            {
                randomId = GetRandomID();
            } while (fishItems.FirstOrDefault(item => string.Compare(item.ID, randomId) == 0) != null);

            fishItems.Add(new FishItem(ingredient, randomId));
        }
    }

    public IngredientsScriptable FindFish(string id)
    {
        return fishItems.FirstOrDefault(item => string.Compare(item.ID, id) == 0)?.ingredient;
    }

    public void GenerateFish(string id) {
        IngredientsScriptable ingredientToSpawn = FindFish(id);
        if (ingredientToSpawn == null) {
            Debug.Log("Fish Not FOUND!");
            return;
        }

        GenerateIngredient(ingredientToSpawn);
        RandomizeAllID();
    }

    public void RandomizeAllID() {
        foreach (FishItem item in fishItems) {
            string randomId;
            do
            {
                randomId = GetRandomID();
            } while (fishItems.FirstOrDefault(item => string.Compare(item.ID, randomId) == 0) != null);
            item.ID = randomId;
        }
    }

    public string GetRandomID() 
    {
        //A-D
        char letter = (char)(65 + UnityEngine.Random.Range(0, 3));
        //1-4
        int num = UnityEngine.Random.Range(1, 4);

        return letter + num.ToString();
    }
}

[Serializable]
public class FishItem
{
    public IngredientsScriptable ingredient;
    public string ID;
    public FishItem(IngredientsScriptable _ingredient, string _id)
    {
        ingredient = _ingredient;
        ID = _id;
    }
}
