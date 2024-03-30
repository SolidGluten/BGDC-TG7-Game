using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class OrderChute : MonoBehaviour
{
    public OrderList orderList;
    public GameObject foodHolder;
    public Room cashierRoom;

    private void Start()
    {
        cashierRoom = GetComponentInParent<Room>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            if (foodHolder == null)
            {
                foodHolder = collision.gameObject;
                cashierRoom.roomElevator.foodObj = null;
                foodHolder.GetComponent<Dragable>().SetLastPosition(transform);
            }
            else
            {
                #region Mixing
                if (foodHolder == collision.gameObject) return;

                FoodHolder addedTo = foodHolder.GetComponent<FoodHolder>();
                FoodHolder adder = collision.GetComponent<FoodHolder>();
                GameObject mixedFood = Mixer.instance.MixFood(addedTo, adder);

                if (mixedFood == null)
                {
                    Debug.Log("No mix recipe found!");
                    return;
                }

                foodHolder = mixedFood;
                mixedFood.GetComponent<Dragable>().SetLastPosition(transform);
                mixedFood.GetComponent<Dragable>().ResetPosition();
                #endregion
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject == foodHolder)
        {
            foodHolder = null;
        }
    }

    public void SendOrder()
    {
        if(foodHolder != null)
        {
            Order orderToServe = orderList.FindOrder(foodHolder.GetComponent<FoodHolder>());
            if(orderToServe == null) {
                GameManager.instance.Death(DeathCondition.WrongOrder);
            } else
            {
                orderList.RemoveOrder(orderToServe);
                LevelManager.instance.UpdateOrderCount();
            }
            Destroy(foodHolder);
        }
    }
}
