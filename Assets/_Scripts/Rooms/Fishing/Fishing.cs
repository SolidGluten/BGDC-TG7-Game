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
    public float currentFishTime;
    public float currentTimeBeforeDeath;

    public void Fish(BaseIngredient ingredient)
    {
        StopAllCoroutines();
        StartCoroutine(I_Fish(ingredient));
    }

    public IEnumerator I_Fish(BaseIngredient ingredient)
    {
        FoodScriptable ingredientToSpawn = FindIngredients(ingredient);
        if (ingredientToSpawn == null)
        {
            Debug.Log("No ingredients found!");
            yield break;
        }

        isFishing = true;

        currentFishTime = 0;
        currentTimeBeforeDeath = 0;

        while (currentFishTime < maxFishTime)
        {
            currentFishTime += Time.deltaTime;
            Debug.Log(currentFishTime);
            yield return null;
        }

        GenerateIngredient(ingredientToSpawn);
        isFishing = false;

        while (currentTimeBeforeDeath < maxTimeBeforeDeath)
        {
            if(ingredientHolder.ingredient == null)
            {
                currentFishTime = 0;
                currentTimeBeforeDeath = 0;
                yield break;
            }
            currentTimeBeforeDeath += Time.deltaTime;
            Debug.Log(currentTimeBeforeDeath);
            yield return null;
        }

        if (currentTimeBeforeDeath >= maxTimeBeforeDeath && ingredientHolder.ingredient != null)
        {
            GameManager.instance.Death(DeathCondition.Fishing);
        }
    }
    
}
