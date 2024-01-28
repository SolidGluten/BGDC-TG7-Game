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
            GameObject order = orderList.FindOrder(collision.gameObject.GetComponent<FoodHolder>().food);
            if(order == null)
            {
                //Death Condition;
                Destroy(collision.gameObject);
                return;
            }
            orderList.RemoveOrder(order);
            Destroy(collision.gameObject);
        }
    }

}
