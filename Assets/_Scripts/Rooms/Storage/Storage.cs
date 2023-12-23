using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

public class Storage : Generator
{
    public Transform spawnPos;
    public BaseIngredient ingredientToSpawn;

    public void SpawnIngredient()
    {
        GenerateIngredient(spawnPos.transform.position, ingredientToSpawn);
    }
}
