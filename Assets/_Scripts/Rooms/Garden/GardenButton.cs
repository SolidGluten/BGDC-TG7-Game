using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GardenButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Garden garden;

    private void OnMouseDown()
    {
        if(garden.isGrowing == false)
            StartCoroutine(garden.Plant(ingredient));
    }
}
