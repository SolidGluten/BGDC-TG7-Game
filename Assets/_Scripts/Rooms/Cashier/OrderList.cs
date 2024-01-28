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


    private void Update()
    {
        //hides the UI by scaling it to zero if the cashier room is not active
        if (cashierRoom.activeInHierarchy)
        {
            GetComponent<RectTransform>().localScale = Vector2.one;
        }
        else
        {
            GetComponent<RectTransform>().localScale = Vector2.zero;
        }
    }

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

