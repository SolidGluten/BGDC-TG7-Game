using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GenerateButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Storage storage;

    private void Start()
    {
        storage = FindAnyObjectByType<Storage>();
    }

    private void OnMouseDown()
    {
        storage.ingredientToSpawn = ingredient;
        storage.SpawnIngredient();
    }
}
