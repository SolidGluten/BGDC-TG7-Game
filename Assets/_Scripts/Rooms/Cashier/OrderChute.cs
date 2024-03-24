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

    private void Update()
    {
        if (foodHolder == cashierRoom.roomElevator.foodObj && foodHolder != null) {
            foodHolder = null;
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food") && foodHolder == null)
        {
            foodHolder = collision.gameObject;
            cashierRoom.roomElevator.foodObj = null;
            foodHolder.GetComponent<Dragable>()?.SetLastPosition(transform);
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
