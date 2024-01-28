using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    public FoodHolder foodHolder;
    public FoodScriptable foodScriptable;

    private void Start()
    {
        foodHolder.food = foodScriptable;
    }
}
