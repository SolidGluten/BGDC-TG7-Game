using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderManager : MonoBehaviour
{
    public OrderList orderList;
    public GameObject orderPrefab;
    public DishScriptable dishScriptable;

    public float arrivalTimer;

    public SimpleOrders simple;
    public MediocreOrders mediocre;
    public AdvancedOrders advance;

    private void Start()
    {
        SendNewOrder(dishScriptable);
        arrivalTimer = GetRandomArrival();
    }

    private void Update()
    {
        if(arrivalTimer > 0)
        {
            arrivalTimer -= Time.deltaTime;
        } else
        {
            arrivalTimer = GetRandomArrival();
            SendNewOrder(GetRandomDish());
        }
    }

    private float GetRandomArrival() => GameManager.MaxPatience + UnityEngine.Random.Range(-7, 3);

    private DishScriptable GetRandomDish()
    {
        //Pick random tier
        int total = simple.SimpleRate + mediocre.MediocreRate + advance.AdvancedRate;
        int rand = UnityEngine.Random.Range(0, total);
        if(rand < simple.SimpleRate)
        {
            var random = new System.Random();
            var index = random.Next(simple.SimpleOrderList.Count);
            return simple.SimpleOrderList[index];
        } else if(rand < mediocre.MediocreRate)
        {
            var random = new System.Random();
            var index = random.Next(mediocre.MediocreOrderList.Count);
            return mediocre.MediocreOrderList[index];
        } else
        {
            var random = new System.Random();
            var index = random.Next(advance.AdvancedOrderList.Count);
            return advance.AdvancedOrderList[index];
        }
    }

    private void SendNewOrder(DishScriptable newDish)
    {
        orderList.AddOrder(newDish);
    }
}

[Serializable]
public class SimpleOrders
{
    public int SimpleRate;
    public List<DishScriptable> SimpleOrderList = new List<DishScriptable>();
}

[Serializable]
public class MediocreOrders
{
    public int MediocreRate;
    public List<DishScriptable> MediocreOrderList = new List<DishScriptable>();
}

[Serializable]
public class AdvancedOrders
{
    public int AdvancedRate;
    public List<DishScriptable> AdvancedOrderList = new List<DishScriptable>();
}
