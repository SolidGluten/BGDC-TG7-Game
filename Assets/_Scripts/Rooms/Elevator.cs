using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class Elevator : MonoBehaviour
{
    public GameObject foodObj;

    private void OnEnable()
    {
        if (foodObj != null)
        {
            foodObj.GetComponent<Dragable>().SetLastPosition(transform.position);
            foodObj.GetComponent<Dragable>().ResetPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            if (foodObj == null)
            {
                foodObj = collision.gameObject;
                foodObj.GetComponent<Dragable>().SetLastPosition(transform.position);
            } else
            {
                if (foodObj == collision.gameObject) return;

                FoodScriptable addedTo = foodObj.GetComponent<FoodHolder>().food;
                FoodScriptable adder = collision.GetComponent<FoodHolder>().food;

                if(adder._foodType == FoodType.SideDish && addedTo._sideDish == SideDish.None)
                {
                    //If dish + sideDish combination
                    Mixer.instance.AddSideDish(foodObj.GetComponent<FoodHolder>(), adder._sideDish);
                    Destroy(collision.gameObject);
                } else if (adder._foodType == FoodType.Beverage && addedTo._drink == DrinkType.None)
                {
                    //If dish + beverage combination
                    Mixer.instance.AddDrink(foodObj.GetComponent<FoodHolder>(), adder._drink);
                    Destroy(collision.gameObject);
                }
                else{
                    //If dish + dish combination
                    FoodScriptable output = Mixer.instance.FindRecipe(addedTo, adder);
                    if (output == null)
                    {
                        Debug.Log("No recipe found!");
                        return;
                    }
                    Mixer.instance.MakeMix(output, transform.position, transform.parent);
                    Destroy(foodObj);
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
