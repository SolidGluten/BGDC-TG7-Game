using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;
using System;
using System.Linq;

public class Fishing : Generator
{
    public float maxFishTime;
    public float maxTimeBeforeDeath;
    public bool isFishing = false;
    [SerializeField] float currentFishTime;
    [SerializeField] float currentTimeBeforeDeath;

    public IEnumerator Fish(BaseIngredient ingredient)
    {
        isFishing = true;
        FoodScriptable ingredientToSpawn = FindIngredients(ingredient);
        if (ingredientToSpawn == null)
        {
            Debug.Log("No ingredients found!");
            isFishing = false;
            yield break;
        }

        currentFishTime = maxFishTime;
        currentTimeBeforeDeath = maxTimeBeforeDeath;

        while (currentFishTime > 0)
        {
            currentFishTime -= Time.deltaTime;
            Debug.Log(currentFishTime);
            yield return null;
        }

        GenerateIngredient(ingredientToSpawn);
        isFishing = false;

        while (currentTimeBeforeDeath > 0 && ingredientHolder.ingredient != null)
        {
            currentTimeBeforeDeath -= Time.deltaTime;
            Debug.Log(currentTimeBeforeDeath);
            yield return null;
        }
        if (currentTimeBeforeDeath <= 0 && ingredientHolder.ingredient != null)
        {
            GameManager.instance.Death(DeathCondition.Fishing);
        }
    }
    
}
