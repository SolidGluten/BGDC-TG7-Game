using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class OrderChute : MonoBehaviour
{
    public OrderList orderList;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            orderList.RemoveOrder(collision.GetComponent<FoodHolder>().food);
            Destroy(collision.gameObject);
        }
    }

}
