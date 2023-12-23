using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(Generator))]
public class Storage : MonoBehaviour
{
    public Generator StorageGenerator;
    public Transform spawnPos;
    public BaseIngredient ingredientToSpawn;

    private void Start()
    {
        StorageGenerator = GetComponent<Generator>();
    }

    public void SpawnIngredient()
    {
        StorageGenerator.GenerateIngredient(spawnPos.transform.position, ingredientToSpawn);
    }
}
