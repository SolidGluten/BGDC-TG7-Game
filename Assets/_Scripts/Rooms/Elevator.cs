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
            #region Mixing
            if (foodObj == null)
            {
                foodObj = collision.gameObject;
                foodObj.GetComponent<Dragable>().SetLastPosition(transform);
            } else
            {
                if (foodObj == collision.gameObject) return;

                FoodScriptable addedTo = foodObj.GetComponent<FoodHolder>().food;
                FoodScriptable adder = collision.GetComponent<FoodHolder>().food;

                if (adder._foodType == FoodType.SideDish && addedTo._sideDish == SideDish.None)
                {
                    //If dish + sideDish combination
                    Mixer.instance.AddSideDish(foodObj.GetComponent<FoodHolder>(), adder._sideDish);
                    Destroy(collision.gameObject);
                } else if (addedTo._foodType == FoodType.SideDish && adder._sideDish == SideDish.None) 
                {
                    //If sideDish + dish combination
                    Mixer.instance.AddSideDish(collision.GetComponent<FoodHolder>(), addedTo._sideDish);
                    Destroy(foodObj);
                } else if (adder._foodType == FoodType.Beverage && addedTo._drink == DrinkType.None)
                {
                    //If dish + beverage combination
                    Mixer.instance.AddDrink(foodObj.GetComponent<FoodHolder>(), adder._drink);
                    Destroy(collision.gameObject);
                } else if (addedTo._foodType == FoodType.Beverage && adder._drink == DrinkType.None)
                {
                    //If beverage + dish combination
                    Mixer.instance.AddDrink(collision.GetComponent<FoodHolder>(), addedTo._drink);
                    Destroy(foodObj);
                }
                else {
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
            #endregion
        }
    }
}
