using System.Collections;
using System.Collections.Generic;
using Types;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class FishingButton : MonoBehaviour
{
    public BaseIngredient ingredient;
    public Fishing fishing;

    private void OnMouseDown()
    {
        fishing.Fish(ingredient);
    }
}
