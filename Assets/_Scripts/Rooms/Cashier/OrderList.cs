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

    public void AddOrder(FoodScriptable dish, bool addSides, bool addDrink, bool addFermented)
    {
        GameObject newOrder = Instantiate(orderObjPrefab, transform.position, Quaternion.identity, orderContainer);
        Order order = newOrder.GetComponent<Order>();
        order.orderDish = dish;
        if (addSides) order.SetRandomSides();
        if (addDrink) order.SetRandomDrink();
        if (addFermented) {
            float rand = Random.Range(0f, 1f);
            if(rand < .4f) order.IsOrderFermented = true;
            else order.IsOrderFermented = false;
        }
        order.orderList = this;
        activeOrders.Add(order);
    }

    public Order FindOrder(FoodHolder foodHolder)
    {
        Order orderToFind = activeOrders
            .FirstOrDefault(order => order.orderDish == foodHolder.FoodScript && 
            order.OrderDrink == foodHolder.DrinkType && 
            order.OrderSideDish == foodHolder.SideDish && 
            order.IsOrderFermented == foodHolder.IsFermented);
        return orderToFind ? orderToFind : null;
    }

    public bool RemoveOrder(Order order)
    {
        Order orderToRemove = activeOrders.FirstOrDefault(_order => _order == order);

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

