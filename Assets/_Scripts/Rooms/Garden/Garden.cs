using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Types;
using UnityEngine;

public class Garden : Generator
{
    public List<Item> PlantItems = new List<Item>();
    public bool isSlotOpen;

    public Room room;
    private void Start()
    {
        room = GetComponent<Room>();
    }

    public void Awake()
    {
        RandomizeAllID();
    }

    public void UnlockPlant(string id) {
        if (isSlotOpen) return;
        var item = PlantItems.FirstOrDefault(item => string.Compare(item.currentId, id) == 0);
        if (item != null) item.UnlockItem();
        else GameManager.instance.Death(DeathCondition.Garden);
    }

    public GameObject GeneratePlant(BaseIngredient ingredient, Transform spawnPos)
    {
        FoodScriptable ingredientToSpawn = FindIngredients(ingredient);
        if (ingredientToSpawn == null)
        {
            Debug.Log("Plant Not FOUND!");
            return null;
        }

        return SpawnIngredient(ingredientToSpawn, spawnPos);
    }

    public void RandomizeAllID()
    {
        foreach (Item item in PlantItems)
        {
            string randomId;
            do
            {
                randomId = GetRandomID();
            } while (PlantItems.FirstOrDefault(item => string.Compare(item.currentId, randomId) == 0) != null);
            item.UpdateID(randomId);
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