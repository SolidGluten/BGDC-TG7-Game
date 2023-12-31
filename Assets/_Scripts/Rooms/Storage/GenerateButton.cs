using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GenerateButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Generator generator;

    private void OnMouseDown()
    {
        generator.ingredientToSpawn = ingredient;
        generator.GenerateIngredient();
    }
}
