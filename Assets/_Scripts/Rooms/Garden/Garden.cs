using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class Garden : Generator
{
    public float maxGrowTime;
    public float maxTimeBeforeDeath;
    public bool isGrowing = false;
    [SerializeField] float currentGrowTime;
    [SerializeField] float currentTimeBeforeDeath;

    public IEnumerator Plant(BaseIngredient ingredient)
    {
        isGrowing = true;
        IngredientsScriptable ingredientToSpawn = FindIngredients(ingredient);
        if (ingredientToSpawn == null) {
            Debug.Log("No ingredients found!");
            isGrowing=false;
            yield break;
        }

        currentGrowTime = maxGrowTime;
        currentTimeBeforeDeath = maxTimeBeforeDeath;

        while (currentGrowTime > 0)
        {
            currentGrowTime -= Time.deltaTime;
            Debug.Log(currentGrowTime);
            yield return null;
        }

        GenerateIngredient(ingredientToSpawn);
        isGrowing = false;

        while (currentTimeBeforeDeath > 0 && ingredientHolder.ingredient != null)
        {
            currentTimeBeforeDeath -= Time.deltaTime;
            Debug.Log(currentTimeBeforeDeath);
            yield return null;
        }
    }
}
