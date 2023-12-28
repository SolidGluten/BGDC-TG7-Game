using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientHolder : MonoBehaviour
{
    public GameObject ingredient;
    public Elevator elevator;

    private void Update()
    {
        if(elevator.foodObj == ingredient)
        {
            ingredient = null;
        }
    }
}
