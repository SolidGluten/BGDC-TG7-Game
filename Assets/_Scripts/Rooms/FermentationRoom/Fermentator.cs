using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Fermentator : MonoBehaviour
{
    FermentationRoom fermentRoom;

    private void Start()
    {
        fermentRoom = GetComponentInParent<FermentationRoom>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            FoodHolder raw = collision.GetComponent<FoodHolder>();
            FoodScriptable fermentedFood = fermentRoom.FindOutputDish(raw.FoodScript);
            if(fermentedFood == null)
            {
                Debug.Log("Fermented food not found!");
                return;
            }

            raw.GetComponent<Dragable>().SetLastPosition(transform);
            fermentRoom.room.roomElevator.foodObj = null;
            StartCoroutine(fermentRoom.Ferment(raw));
        }
    }
}
