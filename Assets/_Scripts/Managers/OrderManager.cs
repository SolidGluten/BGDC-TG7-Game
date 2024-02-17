using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class OrderManager : MonoBehaviour
{
    public OrderList orderList;

    public float arrivalTimer;
    public float arrivalTimeIfNone = 3f;

    [SerializeField] private bool isDrinkAdded;
    [SerializeField] private bool isSideDishAdded;
    [SerializeField] private bool isFermentedAdded;

    public Orders simple;
    public Orders mediocre;
    public Orders advance;


    private void Start()
    {
        SendNewOrder();
        arrivalTimer = GetRandomArrival();
    }

    private void Update()
    {
        if (arrivalTimer > 0)
        {
            arrivalTimer -= Time.deltaTime;

            //if there is no order, reduce the arrival time
            if(orderList.activeOrders.Count == 0 && arrivalTimer > arrivalTimeIfNone)
            {
                arrivalTimer -= arrivalTimer - arrivalTimeIfNone;
            }
        }
        else
        {
            arrivalTimer = GetRandomArrival();
            SendNewOrder();
        }
    }

    private float GetRandomArrival() => LevelManager.instance.MaxPatience + UnityEngine.Random.Range(-10, 0);

    private FoodScriptable GetRandomDish()
    {
        //Pick random tier
        FoodScriptable randomDish;
        int total = simple._spawnChance + mediocre._spawnChance + advance._spawnChance;
        int rand = UnityEngine.Random.Range(0, total);
        if (rand < simple._spawnChance)
        {
            var random = new System.Random();
            var index = random.Next(0, simple._orderList.Count);
            randomDish = simple._orderList[index];
        }
        else if (rand < mediocre._spawnChance + simple._spawnChance)
        {
            var random = new System.Random();
            var index = random.Next(0, mediocre._orderList.Count);
            randomDish = mediocre._orderList[index];
        }
        else
        {
            var random = new System.Random();
            var index = random.Next(0, advance._orderList.Count);
            randomDish = advance._orderList[index];
        }

        return randomDish;
    }

    private void SendNewOrder()
    {
        orderList.AddOrder(GetRandomDish(), isSideDishAdded, isDrinkAdded, isFermentedAdded);
    }
}

[Serializable]
public class Orders
{
    public int _spawnChance;
    public List<FoodScriptable> _orderList = new List<FoodScriptable>();
}
