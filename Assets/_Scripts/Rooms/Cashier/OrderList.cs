using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class OrderList : MonoBehaviour
{
    public List<GameObject> activeOrders = new List<GameObject>();

    public void AddOrder(GameObject orderPrefab)
    {
        GameObject orderObj = Instantiate(orderPrefab, transform.position, Quaternion.identity);
        orderObj.transform.SetParent(transform);
        activeOrders.Add(orderObj);
    }

    public void RemoveOrder(GameObject orderPrefab)
    {
        GameObject orderObj = activeOrders.FirstOrDefault(obj => obj == orderPrefab);

        if(orderObj == null)
        {
            Debug.Log("Order not found");
            return;
        }

        activeOrders.Remove(orderObj);
        Destroy(orderObj);
    }
}
