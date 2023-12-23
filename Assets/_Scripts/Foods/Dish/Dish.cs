using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dish : MonoBehaviour
{
    public DishScriptable dishScriptable;

    private void Start()
    {
        gameObject.name = dishScriptable.name;
        GetComponent<SpriteRenderer>().sprite = dishScriptable.dishSprite;
    }
}
