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
            foodHolder = collision.gameObject;
            cashierRoom.roomElevator.foodObj = null;
            foodHolder.GetComponent<Dragable>()?.SetLastPosition(transform.position);
        }
    }

    public void SendOrder()
    {
        if(foodHolder != null)
        {
            orderList.RemoveOrder(foodHolder.GetComponent<FoodHolder>().food);
            Destroy(foodHolder);
        }
    }
}
