using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Fermentator : MonoBehaviour
{
    FermentationRoom fermentRoom;

    public List<FoodScriptable> fermentFoodList = new List<FoodScriptable>();

    public Transform outputPos;

    private void Start()
    {
        fermentRoom = GetComponentInParent<FermentationRoom>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            FoodHolder raw = collision.GetComponent<FoodHolder>();
            FoodScriptable fermentedFood = fermentFoodList.FirstOrDefault(food => food == raw.FoodScript);
            if (raw.IsFermented)
            {
                Debug.Log("Food is already fermented");
                return;
            }

            if(fermentedFood == null)
            {
                Debug.Log("Fermented food not found!");
                return;
            }

            raw.GetComponent<Dragable>().SetLastPosition(outputPos);
            raw.GetComponent<Dragable>().ResetPosition();
            fermentRoom.room.roomElevator.foodObj = null;
            raw.IsFermented = true;
        }
    }
}
