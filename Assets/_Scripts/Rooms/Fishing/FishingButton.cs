using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FishingButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Fishing fishing;
    public Coroutine fish;

    private void OnMouseDown()
    {
        if (fishing.isFishing == false)
            if(fish != null) StopCoroutine(fish);
            fish = StartCoroutine(fishing.Fish(ingredient));
    }
}
