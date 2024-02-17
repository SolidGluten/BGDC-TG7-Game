using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class Elevator : MonoBehaviour
{
    public GameObject foodObj;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            
            if (foodObj == null)
            {
                foodObj = collision.gameObject;
                foodObj.GetComponent<Dragable>().SetLastPosition(transform);
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
                mixedFood.GetComponent<Dragable>().SetLastPosition(transform);
                mixedFood.GetComponent<Dragable>().ResetPosition();
                #endregion
            }
        }
    }
}
