using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public GameObject cashierRoom;
    public GameObject orderObjPrefab;
    public Transform orderContainer;
    public List<Order> activeOrders = new List<Order>();

    public void AddOrder(FoodScriptable dish)
    {
        GameObject newOrder = Instantiate(orderObjPrefab, transform.position, Quaternion.identity, orderContainer);
        Order order = newOrder.GetComponent<Order>();
        order.orderDish = dish;
        order.orderList = this;
        activeOrders.Add(order);
    }

    public bool RemoveOrder(FoodScriptable dish)
    {
        Order orderToRemove = activeOrders.FirstOrDefault(order => order.orderDish == dish);

        if(orderToRemove == null)
        {
            Debug.Log("No Order Found!");
            return false;
        }

        activeOrders.Remove(orderToRemove);
        Destroy(orderToRemove.gameObject);
        return true;
    }
}

