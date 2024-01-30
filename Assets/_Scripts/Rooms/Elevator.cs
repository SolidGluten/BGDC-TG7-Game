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

                FoodHolder addedTo = foodObj.GetComponent<FoodHolder>();
                FoodHolder adder = collision.GetComponent<FoodHolder>();

                //Mix dishes
                if(addedTo.type == FoodType.Dish && adder.type == FoodType.Dish){
                    FoodScriptable output = Mixer.instance.FindRecipe(addedTo.food, adder.food);
                    if (output == null)
                    {
                        Debug.Log("No recipe found!");
                        return;
                    }
                    Mixer.instance.MakeMix(output, transform.position, transform.parent);
                    Destroy(foodObj);
                    Destroy(collision.gameObject);
                }

                if (addedTo.type == adder.type) return;

                //Add side dish
                if(addedTo.type == FoodType.SideDish || adder.type == FoodType.SideDish)
                {
                    FoodHolder sideDishHolder = addedTo.type == FoodType.SideDish ? addedTo : adder;
                    FoodHolder foodHolder = addedTo.type != FoodType.SideDish ? addedTo : adder;

                    Mixer.instance.AddSideDish(foodHolder, sideDishHolder.sideDish);
                    foodObj = foodHolder.gameObject;
                    foodHolder.GetComponent<Dragable>().SetLastPosition(transform);
                    Destroy(sideDishHolder.gameObject);
                }

                //Add drink
                if(addedTo.type == FoodType.Beverage || adder.type == FoodType.Beverage)
                {
                    FoodHolder drinkHolder = addedTo.type == FoodType.Beverage ? addedTo : adder;
                    FoodHolder foodHolder = addedTo.type != FoodType.Beverage ? addedTo : adder;

                    Mixer.instance.AddDrink(foodHolder, drinkHolder.drinkType);
                    foodObj = foodHolder.gameObject;
                    foodHolder.GetComponent<Dragable>().SetLastPosition(transform);
                    Destroy(drinkHolder.gameObject);
                }
            }
            #endregion
        }
    }
}
