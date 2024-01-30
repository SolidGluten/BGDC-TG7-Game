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
            FoodScriptable raw = collision.GetComponent<FoodHolder>().food;
            FoodScriptable fermentedFood = fermentRoom.FindOutputDish(raw);
            if(fermentedFood == null)
            {
                Debug.Log("Fermented food not found!");
                return;
            }

            fermentRoom.Ferment(transform, fermentedFood);
            Destroy(collision.gameObject);
        }
    }
}
