using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public GameObject cashierRoom;
    public GameObject orderObjPrefab;
    public Transform orderContainer;
    public List<GameObject> orderObjects = new List<GameObject>();


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
        orderObjects.Add(newOrder);
    }

    public void RemoveOrder(GameObject orderToRemove)
    {
        orderObjects.Remove(orderToRemove);
        Destroy(orderToRemove);
    }

    public GameObject FindOrder(FoodScriptable dish)
    {
        GameObject order = orderObjects.FirstOrDefault(order => order.GetComponent<Order>().orderDish == dish);
        return order ? order : null;
    }
}

