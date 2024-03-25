using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class Elevator : MonoBehaviour
{
    public GameObject foodObj;
    public Transform foodPos;

    private void Start()
    {
        foodPos = GetComponentsInChildren<Transform>()[1];  
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            if (foodObj == null)
            {
                foodObj = collision.gameObject;
                foodObj.GetComponent<Dragable>().SetLastPosition(foodPos);
            } else
            {
                #region Mixing
                if (foodObj == collision.gameObject) return;

                FoodHolder addedTo = foodObj.GetComponent<FoodHolder>();    
                FoodHolder adder = collision.GetComponent<FoodHolder>();
                GameObject mixedFood = Mixer.instance.MixFood(addedTo, adder);

                if (mixedFood == null) {
                    Debug.Log("No mix recipe found!");
                    return;
                }

                foodObj = mixedFood;
                mixedFood.GetComponent<Dragable>().SetLastPosition(foodPos);
                mixedFood.GetComponent<Dragable>().ResetPosition();
                #endregion
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        foodObj = null;
    }
}
