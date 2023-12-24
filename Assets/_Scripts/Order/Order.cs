using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public string orderName;
    public SpriteRenderer orderSpriteRender;
    public OrderScriptable orderScriptable;

    private void Start()
    {
        orderName = orderScriptable.orderName;
        orderSpriteRender.sprite = orderScriptable.orderSprite;
    }
}
