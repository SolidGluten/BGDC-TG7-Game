using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class OrderManager : MonoBehaviour
{
    public OrderList orderList;

    public float arrivalTimer;

    [SerializeField] private bool isDrinkAdded;
    [SerializeField] private bool isSideDishAdded;

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
        }
        else
        {
            arrivalTimer = GetRandomArrival();
            SendNewOrder();
        }
    }

    private float GetRandomArrival() => GameManager.MaxPatience + UnityEngine.Random.Range(-7, 3);

    private FoodScriptable GetRandomDish()
    {
        //Pick random tier
        FoodScriptable randomDish;
        int total = simple._spawnChance + mediocre._spawnChance + advance._spawnChance;
        int rand = UnityEngine.Random.Range(0, total);
        if (rand < simple._spawnChance)
        {
            var random = new System.Random();
            var index = random.Next(simple._orderList.Count);
            randomDish = simple._orderList[index];
        }
        else if (rand < mediocre._spawnChance)
        {
            var random = new System.Random();
            var index = random.Next(mediocre._orderList.Count);
            randomDish = mediocre._orderList[index];
        }
        else
        {
            var random = new System.Random();
            var index = random.Next(advance._orderList.Count);
            randomDish = advance._orderList[index];
        }

        return randomDish;
    }

    private void SendNewOrder()
    {
        orderList.AddOrder(GetRandomDish(), isSideDishAdded, isDrinkAdded);
    }
}

[Serializable]
public class Orders
{
    public int _spawnChance;
    public List<FoodScriptable> _orderList = new List<FoodScriptable>();
}
