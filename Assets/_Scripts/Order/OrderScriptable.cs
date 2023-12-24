using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Order/NewOrder")]
public class OrderScriptable : ScriptableObject
{
    public string orderName;
    public Sprite orderSprite;
    public DishScriptable dishOrder;
}
